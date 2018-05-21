using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace TilesMaker
{
    public partial class TilesMaker : Form
    {
        //główne składniki
        Bitmap sourcePicture; //głowna grafika wczytana z pliku

        Bitmap mainPicture; //główny obrazek powiększony/pomniejszony
        Bitmap shapePicture; //obrazek po narysowaniu na nim krztałtu (lini, koła kwadratu)

        Bitmap palette; //grafika z paletmai kolorów
        Bitmap fullPalette; //grafika z grafikami rozciągniętymi i ustawionymi

        Random rnd;

        UndoClass undo;

        //ustawienia
        int             scale = 10; //powiększenie głównego obrazka
        int             gridScale = 10; //ile obrazków znajduje sie na szerokości siatki
        int             globalSize = 32; //rzeczywisty rozmiar grafiki
        int             gridPixelSize = 1; //rozmiar piksela na siatce
        float           grayScaleValue = 0.5f;
        int             newImageSize = 32; //rozmiar obrazka który się utworzy po kliknięciu przysisku new image
        int             saveType = 0; //0 oba | 1 tylko kolor | 2 tylko szary

        bool            realTimeOverview = false;
        bool            endDrawLine = false;

        string          savePath = "";

        public bool     undoPhase = false;

        //pędzle i ich własności
        List<UInt32>    brushColor;
        HashSet<int>    brushIndex;
        HashSet<int>    brushAltIndex;
        bool            leftBrush;
        bool            rightBrush;
        int             mousePosX;
        int             mousePosY;
        int             lastScalePosX;
        int             lastScalePosY;
        
        int             startDrawPosX; //pozycja startowa rysowania linii kwadratu lub koła
        int             startDrawPosY;

        int             brushType;
        List<Point>     multiPixel; //pozcje pikseli które zostaną zmienione 
        Queue<Point>    multiQueue; //kolejka służąca do obliczeń pokseli do zmiany

        Thread  drawThread;

        public TilesMaker()
        {
            //informacje do rysowania
            leftBrush = false;
            rightBrush = false;
            mousePosX = 0;
            mousePosY = 0;
            lastScalePosX = -1;
            lastScalePosY = -1;
            brushType = 0;
            startDrawPosX = -1;
            startDrawPosY = -1;
            multiPixel = new List<Point>();
            multiQueue = new Queue<Point>();

            endDrawLine = false;
            realTimeOverview = false;

            rnd = new Random();

            undo = new UndoClass(this);
            //List<Bitmap> undoPalette = new List<Bitmap>();
            //List<Bitmap> redoPalette = new List<Bitmap>();

            //osobny wątek na którym odbywa się wysowanie
            drawThread = new Thread(Drawer);
            drawThread.IsBackground = true;
            drawThread.Start();

            savePath = "";

            InitializeComponent();

            CreateNewGFX(); //tworzenie czystej grafiki

            //ustawianie kolorów do rysowania
            brushColor = new List<UInt32>();
            brushIndex = new HashSet<int>();
            brushAltIndex = new HashSet<int>();
            brushIndex.Add(255); //wybranie kolorów dla pędzli
            brushAltIndex.Add(0);

            LoadColorSelector(); //narysowanie grafiki z wyborem kolorów

            serverSocket = null;
            clientSockets = new List<Socket>();
            clientAmount = 0;


            //this.MainImage.
        }

        public void DebugLog(string deb)
        {
            DEBUG.Text = deb;
        }

        private UInt32 RandomColor(int listID)
        {
            UInt32 tempColor = 0xFF000000;//Color.FromArgb(0, 0, 0);
            if(listID == 0)
            {
                if(brushIndex.Count() > 1)
                {
                    tempColor = brushColor[brushIndex.ElementAt(rnd.Next(0, brushIndex.Count()))];
                }
                else
                {
                    tempColor = brushColor[brushIndex.ElementAt(0)];
                }
            }
            else if (listID == 1)
            {
                if (brushAltIndex.Count() > 1)
                {
                    tempColor = brushColor[brushAltIndex.ElementAt(rnd.Next(0, brushAltIndex.Count()))];
                }
                else
                {
                    tempColor = brushColor[brushAltIndex.ElementAt(0)];
                }
            }
            return tempColor;
        }

        public UInt32 UIntToGrayValue(UInt32 color, float grayPower) //zmienia kolor na odpowiednią szarą wartość
        {
            byte[] byteArray = BitConverter.GetBytes(color);
            int val = (int)(byteArray[0] * 0.2126f + byteArray[1] * 0.7152f + byteArray[2] * 0.0722);
            if (grayPower > 0.5f)
            {
                float factor = (255f - val) * (grayPower - 0.5f) * 2f;
                val = val + (int)factor;
            }
            else if (grayPower < 0.5f)
            {
                float factor = (255f - (255f - val)) * (1f - (grayPower * 2f));
                val = val - (int)factor;
            }

            byteArray[0] = (byte)val; byteArray[1] = (byte)val; byteArray[2] = (byte)val;
            return BitConverter.ToUInt32(byteArray, 0);
        }

        public UInt32 ColorToUint32(Color c)
        {
            return (uint)((c.A << 24) | (c.R << 16) | (c.G << 8) | c.B);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void OpenImage_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void RealTimeBrush_CheckedChanged(object sender, EventArgs e)
        {
            realTimeOverview = !realTimeOverview;
            DEBUG.Text = realTimeOverview.ToString();
        }

        //skróty klawiszowe całego programu
        private void GetHotKeys(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.S) //CTRL + SHIFT + S zapisz jako
            {
                SaveAsFile();
            }
            else if (e.Control && e.KeyCode == Keys.S) //CTRL + S zapis
            {
                SaveFile();
            }
            else if (e.KeyCode == Keys.Q) //Q włączenie rysowania pikselem
            {
                SetBrush(0);
            }
            else if (e.KeyCode == Keys.W) //W włączenie rysowania lini
            {
                SetBrush(1);
            }
            else if (e.KeyCode == Keys.E) //E włączenie rysowania kubłem farby
            {
                SetBrush(2);
            }
            else if (e.KeyCode == Keys.A) //A prostotkąt
            {
                SetBrush(3);
            }
            else if (e.KeyCode == Keys.D) //D elipsa
            {
                SetBrush(5);
            }

            if (e.Alt && e.KeyCode == Keys.R) //obrót w lewo
            {
                sourcePicture.RotateFlip(RotateFlipType.Rotate270FlipNone);
                RefreshImageView();
            }
            else if (e.KeyCode == Keys.R) //obrót w prawo
            {
                sourcePicture.RotateFlip(RotateFlipType.Rotate90FlipNone);
                RefreshImageView();
            }

            if (e.KeyCode == Keys.Z) //cofnij
            {
                undo.Undo();
            }
            else if (e.KeyCode == Keys.Y) //ponów
            {
                undo.Redo();
            }
        }

        private void DropEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if(files.Length > 0)
            {
                Properties.Settings.Default.basePath = files[0];
                LoadFile(files[0]);
            }
        }
    }
}
