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

namespace TilesMaker
{
    public partial class TilesMaker
    {
        //przycisk do tworzenia nowej grafiki
        private void NewGfxButton_Click(object sender, EventArgs e)
        {
            CreateNewGFX();
        }

        //tworzy czystą białą karteczkę na podstawie wielkości ustawionej w opcjach
        private unsafe void CreateNewGFX() 
        {
            sourcePicture = new Bitmap(newImageSize, newImageSize);
            BitmapData bmSrc = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), 
                                                      ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            UInt32* prtSrc = (UInt32*)bmSrc.Scan0.ToPointer();

            for (int x = 0; x < sourcePicture.Width; ++x)
            {
                for (int y = 0; y < sourcePicture.Height; ++y)
                {
                    *(prtSrc++) = 0xFFFFFFFF;
                }
            }
            sourcePicture.UnlockBits(bmSrc);

            globalSize = sourcePicture.Width;
            RewindSize();
            RefreshLabels();
            RefreshImageView();
        }

        //przycisk zapisz
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        //przycisk zapisz jako
        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        //zapisanie pod ostatnią sicieżkę z zapisu lub wczytania
        private void SaveFile()
        {
            if (savePath == "") //jeśli grafika, nie została jeszcze nigdzie zapisana
            {
                SaveAsFile();
            }
            else //szybkie zapisanie do pliku
            {
                Properties.Settings.Default.basePath = savePath;
                string format = savePath.Substring(savePath.Length - 4, 4);
                string formatGr = savePath.Substring(0, savePath.Length - 4) + "_gray" + format;

                if (saveType == 0 || saveType == 1) //zapisanie kolorowej grafiki
                {
                    if (format == ".png") sourcePicture.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
                    else if (format == ".jpg") sourcePicture.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else if (format == ".bmp") sourcePicture.Save(savePath, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                if (saveType == 0 || saveType == 2) //zapisanie szarej grafiki
                {
                    if (format == ".png") ImageToGray(sourcePicture, grayScaleValue).Save(formatGr, System.Drawing.Imaging.ImageFormat.Png);
                    else if (format == ".jpg") ImageToGray(sourcePicture, grayScaleValue).Save(formatGr, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else if (format == ".bmp") ImageToGray(sourcePicture, grayScaleValue).Save(formatGr, System.Drawing.Imaging.ImageFormat.Bmp);

                }
            }
        }

        //zapiasanie pliku z wybraniem miejsca zapisu
        private void SaveAsFile()
        { 
            SaveImageWin.InitialDirectory = Properties.Settings.Default.basePath;
            SaveImageWin.Filter = "png image|*.png|jpg image|*.jpg|bmp image|*.bmp";
            SaveImageWin.Title = "Save an Image File";
            SaveImageWin.ShowDialog();

            if (saveType == 0 || saveType == 1) //zapisanie kolorowej grafiki
            {
                if (SaveImageWin.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)SaveImageWin.OpenFile();
                    Properties.Settings.Default.basePath = SaveImageWin.FileName;
                    switch (SaveImageWin.FilterIndex)
                    {
                        case 1:
                            sourcePicture.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                            break;

                        case 2:
                            sourcePicture.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 3:
                            sourcePicture.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                    savePath = SaveImageWin.FileName;
                    fs.Close();
                }
            }
            if (saveType == 0 || saveType == 2) //zapisanie szarej grafiki
            {
                if(saveType == 0) SaveImageWin.FileName = SaveImageWin.FileName.Substring(0, SaveImageWin.FileName.Length - 4) + "_gray" + 
                                                                                        SaveImageWin.FileName.Substring(SaveImageWin.FileName.Length - 4, 4);

                if (SaveImageWin.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)SaveImageWin.OpenFile();
                    Properties.Settings.Default.basePath = SaveImageWin.FileName;
                    switch (SaveImageWin.FilterIndex)
                    {
                        case 1:
                            ImageToGray(sourcePicture, grayScaleValue).Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                        case 2:
                            ImageToGray(sourcePicture, grayScaleValue).Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                        case 3:
                            ImageToGray(sourcePicture, grayScaleValue).Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    }

                    if(saveType == 2) savePath = SaveImageWin.FileName;
                    fs.Close();
                }
            }

        }

        private unsafe void LoadButton_Click(object sender, EventArgs e)
        {
            OpenImageWin.InitialDirectory = Properties.Settings.Default.basePath;
            OpenImageWin.Filter = "png image|*.png|jpg image|*.jpg|bmp image|*.bmp";
            OpenImageWin.FilterIndex = 1;
            OpenImageWin.RestoreDirectory = true;

            DialogResult result = OpenImageWin.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = OpenImageWin.FileName;
                Properties.Settings.Default.basePath = file;
                try
                {
                    //ładowanie grafiki z pliku
                    FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    Bitmap tempMap = (Bitmap)Image.FromStream(stream);

                    int tempW = tempMap.Width;
                    int tempH = tempMap.Height;
                    if (tempH == tempW) //sprawdzanie czy grafika jest odpowiedniego rzmiaru
                    {
                        if (tempW == 64 || tempW == 32 || tempW == 16 || tempW == 8 || tempW == 4)
                        {
                            sourcePicture = tempMap; //wczytanie i odświerzenie grafiki
                            globalSize = tempW; //zapisanie wielkości obrazka
                            RewindSize(); //odświerzenie informacji o obrazku
                            RefreshImageView(); //odświerzenie obrazków
                            RefreshLabels(); //odświerzenie etykiet

                            savePath = file; //zapisanie ścieżki do pliku by można było ją szybko zapisać
                        }
                        else DEBUG.Text = "image have bad size";

                    }
                    else DEBUG.Text = "image have bad size";
                    stream.Close();
                }
                catch (IOException)
                {

                }
            }
        }
    }
}