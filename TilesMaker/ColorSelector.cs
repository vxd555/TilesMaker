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
        private void DrawSelectors()
        {
            Bitmap tempBitmap = new Bitmap(fullPalette);

            HashSet<int> commonColor = new HashSet<int>();
            for (int i = 0; i < brushIndex.Count; ++i)
            {
                for (int j = 0; j < brushAltIndex.Count; ++j)
                {
                    if (brushIndex.ElementAt(i) == brushAltIndex.ElementAt(j))
                    {
                        commonColor.Add(brushIndex.ElementAt(i));
                    }
                }
            }

            for (int i = 0; i < brushIndex.Count; ++i)
            {
                int index = brushIndex.ElementAt(i);
                for (int x = 0; x < 15; ++x)
                {
                    for (int y = 0; y < 18; ++y)
                    {
                        if (x == 0 || x == 1 || y == 0 || y == 1 || x == 14 || x == 13 || y == 17 || y == 16)
                        {
                            tempBitmap.SetPixel(x + index % 8 * 16, y + (index / 8) * 19, Color.FromArgb(255, 109, 13));
                        }
                    }
                }
            }
            for (int i = 0; i < brushAltIndex.Count; ++i)
            {
                int index = brushAltIndex.ElementAt(i);
                for (int x = 0; x < 15; ++x)
                {
                    for (int y = 0; y < 18; ++y)
                    {
                        if (x == 0 || x == 1 || y == 0 || y == 1 || x == 14 || x == 13 || y == 17 || y == 16)
                        {
                            tempBitmap.SetPixel(x + index % 8 * 16, y + (index / 8) * 19, Color.FromArgb(0, 162, 232));
                        }
                    }
                }
            }
            for (int i = 0; i < commonColor.Count; ++i)
            {
                int index = commonColor.ElementAt(i);
                for (int x = 0; x < 15; ++x)
                {
                    for (int y = 0; y < 18; ++y)
                    {
                        if (x == 0 || x == 1 || y == 0 || y == 1 || x == 14 || x == 13 || y == 17 || y == 16)
                        {
                            if (x > 8)
                            {
                                tempBitmap.SetPixel(x + index % 8 * 16, y + (index / 8) * 19, Color.FromArgb(0, 162, 232));
                            }
                            else
                            {
                                tempBitmap.SetPixel(x + index % 8 * 16, y + (index / 8) * 19, Color.FromArgb(255, 109, 13));
                            }
                        }
                    }
                }
            }

            ColorSelector.Image = tempBitmap;
        }

        private void ChooseColorFromSelector(object sender, MouseEventArgs e) //wybieranie kolory
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control) //wybieranie kilku kolorów
                {
                    if (e.Y > 608 || e.X > 256) return;
                    Color tempColor = fullPalette.GetPixel(e.X, e.Y);

                    if (!ColorTestToNoSelect(tempColor, e.X, e.Y)) return;

                    brushIndex.Add((e.X / 16) + (e.Y / 19) * 8);

                    DrawSelectors();

                }
                else //wybranie pojedyńczego koloru
                {
                    if (e.Y > 608 || e.X > 256) return;
                    Color tempColor = fullPalette.GetPixel(e.X, e.Y);

                    if (!ColorTestToNoSelect(tempColor, e.X, e.Y)) return;

                    brushIndex.Clear();
                    brushIndex.Add((e.X / 16) + (e.Y / 19) * 8);

                    DrawSelectors();
                }
            }
            else if (e.Button == MouseButtons.Right) //wybieranie alternatywnego koloru
            {
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control) //wybieranie kilku kolorów
                {
                    if (e.Y > 608 || e.X > 256) return;
                    Color tempColor = fullPalette.GetPixel(e.X, e.Y);

                    if (!ColorTestToNoSelect(tempColor, e.X, e.Y)) return;

                    brushAltIndex.Add((e.X / 16) + (e.Y / 19) * 8);

                    DrawSelectors();
                }
                else //wybranie pojedyńczego koloru
                {
                    if (e.Y > 608 || e.X > 256) return;
                    Color tempColor = fullPalette.GetPixel(e.X, e.Y);

                    if (!ColorTestToNoSelect(tempColor, e.X, e.Y)) return;

                    brushAltIndex.Clear();
                    brushAltIndex.Add((e.X / 16) + (e.Y / 19) * 8);

                    DrawSelectors();
                }
            }
        }

        private unsafe void LoadColorSelector() //ładowanie grafiki z wyborem koloru
        {
            try
            {
                FileStream stream = new FileStream("./palette.png", FileMode.Open, FileAccess.Read);
                palette = (Bitmap)Image.FromStream(stream);

                if (!(palette.Width == 256 && palette.Height == 1))
                {
                    palette = new Bitmap(256, 1, PixelFormat.Format32bppArgb);
                }

                stream.Close();
                DrawColorSelector();
            }
            catch (IOException)
            {
                palette = new Bitmap(256, 1, PixelFormat.Format32bppArgb);
                DrawColorSelector();
            }
            
        }

        private unsafe void DrawColorSelector()
        {
            fullPalette = new Bitmap(256, 608, PixelFormat.Format32bppArgb);

            UInt32 tempColor;

            BitmapData bmPalette = palette.LockBits(new Rectangle(Point.Empty, palette.Size), ImageLockMode.WriteOnly, palette.PixelFormat);
            BitmapData bmFull = fullPalette.LockBits(new Rectangle(Point.Empty, fullPalette.Size), ImageLockMode.WriteOnly, fullPalette.PixelFormat);

            UInt32* ptrPalette = (UInt32*)bmPalette.Scan0.ToPointer();
            UInt32* ptrFull = (UInt32*)bmFull.Scan0.ToPointer();

            brushColor.Clear();

            for (int color = 0; color < 256; ++color)
            {
                tempColor = *ptrPalette++;
                brushColor.Add(tempColor);

                for (int x = 0; x < 14; ++x)
                {
                    for (int y = 0; y < 17; ++y)
                    {
                        *(ptrFull + x + (16 * (color % 8)) + y * fullPalette.Width + (19 * (color / 8)) * fullPalette.Width) = tempColor;
                    }
                }
            }

            palette.UnlockBits(bmPalette);
            fullPalette.UnlockBits(bmFull);

            DrawSelectors();
        }

        //wykluczanie obramówki z możliwości wyboru
        private bool ColorTestToNoSelect(Color tempColor, int ex, int ey) 
        {
            if ((tempColor.R == 0 && tempColor.G == 0 && tempColor.B == 0) || //czarny
                (tempColor.R == 255 && tempColor.G == 109 && tempColor.B == 13) || //pomarańczowy
                (tempColor.R == 0 && tempColor.G == 162 && tempColor.B == 232))   //niebieski
            {
                bool isBlack = false;

                for (int color = 0; color < 256; ++color)
                {
                    if (palette.GetPixel(color, 0) == Color.Black)
                    {
                        for (int x = 0; x < 14; ++x)
                        {
                            for (int y = 0; y < 17; ++y)
                            {
                                if (ex == (x + (16 * (color % 8))) && ey == y + (19 * (color / 8)))
                                {
                                    isBlack = true;
                                }
                            }
                        }
                    }
                }
                if (!isBlack) return false;
            }
            return true;

        }


        //zapisanie palety
        private void SavePaletteButton_Click(object sender, EventArgs e)
        {
            SaveImageWin.InitialDirectory = "./";
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
                            palette.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                            break;

                        case 2:
                            palette.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 3:
                            palette.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }

                    //savePath = SaveImageWin.FileName;

                    fs.Close();
                }
            }
        }

        //wczytanie palety
        private void LoadPaletteButton_Click(object sender, EventArgs e)
        {
            OpenImageWin.InitialDirectory = "./";//Properties.Settings.Default.basePath;
            OpenImageWin.Filter = "png image|*.png|jpg image|*.jpg|bmp image|*.bmp";
            OpenImageWin.FilterIndex = 1;
            OpenImageWin.RestoreDirectory = true;

            DialogResult result = OpenImageWin.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string file = OpenImageWin.FileName;
                Properties.Settings.Default.basePath = file;
                try
                {
                    //ładowanie grafiki z pliku
                    FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    Bitmap tempMap = (Bitmap)Image.FromStream(stream);

                    if (tempMap.Width == 256 && tempMap.Height == 1) //sprawdzanie czy grafika jest odpowiedniego rzmiaru
                    {
                        palette = tempMap; //wczytanie palety
                        DrawColorSelector();
                    }
                    else DEBUG.Text = "palette have bad size";

                    stream.Close();
                }
                catch (IOException)
                {

                }

            }
        }

        //zmiana konkretnego koloru po dwukrotmym kliknięciu
        private void ChangeColorInColorSelector(object sender, MouseEventArgs e)
        {
            SetColorWin.FullOpen = true;

            if (SetColorWin.ShowDialog() == DialogResult.OK)
            {
                palette.SetPixel(e.X / 16 + (e.Y / 19) * 8, 0, SetColorWin.Color);
                brushColor[(e.X / 16) + (e.Y / 19) * 8] = ColorToUint32(SetColorWin.Color);
                DrawColorSelector();
            }
                
        }

    }

}