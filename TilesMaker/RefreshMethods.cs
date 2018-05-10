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
        private void RefreshLabels()
        {
            ImageScaleValueLabel.Text = "x" + scale.ToString();
            GridScaleValueLabel.Text = "x" + gridScale.ToString();
            ImageSizeValueLabel.Text = sourcePicture.Width + " x " + sourcePicture.Height + "px";
        }

        public void RefreshImageView()
        {
            RefreshMainImage();
            RefreshGridImage();
        }

        public void RefreshMainImage()
        {
            mainPicture = ChangeSize(sourcePicture, scale);
            MainImage.Image = mainPicture;
            GrayImage.Image = ImageToGray(mainPicture, grayScaleValue);
        }

        public void RefreshGridImage()
        {
            ColorGrid.Image = CreateGrid(sourcePicture, gridScale);
            GrayGrid.Image = CreateGrid(ImageToGray(sourcePicture, grayScaleValue), gridScale);
        }

        public void RefreshGrayView()
        {
            GrayImage.Image = ImageToGray(ChangeSize(sourcePicture, scale), grayScaleValue);
            GrayGrid.Image = CreateGrid(ImageToGray(sourcePicture, grayScaleValue), gridScale);
        }

        public void RewindSize() //w zależności od wielkości obrazka ustawia odpowiednią skalę i ilość obrazków w sietce
        {
            if (globalSize == 64)
            {
                scale = 5;
                gridScale = 5;
            }
            else if (globalSize == 32)
            {
                scale = 10;
                gridScale = 10;
            }
            else if (globalSize == 16)
            {
                scale = 20;
                gridScale = 20;
            }
            else if (globalSize == 8)
            {
                scale = 40;
                gridScale = 40;
            }
            else if (globalSize == 4)
            {
                scale = 80;
                gridScale = 80;
            }
            gridPixelSize = 1;
        }

        public unsafe Bitmap ChangeSize(Bitmap image, int resize) //zwraca podany obrazek zmieniony względem globalnej skali
        {
            Bitmap dest = new Bitmap(image.Width * resize, image.Height * resize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            BitmapData bmSrc = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadOnly, dest.PixelFormat);// image.PixelFormat);
            BitmapData bmDest = dest.LockBits(new Rectangle(Point.Empty, dest.Size), ImageLockMode.WriteOnly, dest.PixelFormat);

            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();
            UInt32* ptrDest = (UInt32*)bmDest.Scan0.ToPointer();

            UInt32 tempColor;

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    tempColor = *(ptrSrc + x + y * image.Width);

                    for (int row = 0; row < resize; ++row)
                    {
                        for (int col = 0; col < resize; ++col)
                        {
                            *(ptrDest + col + x * resize + row * dest.Width + dest.Width * y * resize) = tempColor;
                        }
                    }

                }
            }

            dest.UnlockBits(bmDest);
            image.UnlockBits(bmSrc);

            return dest;
        }

        public unsafe Bitmap ImageToGray(Bitmap image, float grayPower) //zwraca podany obrazek zmieniony względem globalnej skali
        {
            Bitmap dest = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            BitmapData bmSrc = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadOnly, dest.PixelFormat);
            BitmapData bmDest = dest.LockBits(new Rectangle(Point.Empty, dest.Size), ImageLockMode.WriteOnly, dest.PixelFormat);

            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();
            UInt32* ptrDest = (UInt32*)bmDest.Scan0.ToPointer();

            UInt32 tempColor;

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    tempColor = *ptrSrc++;
                    *ptrDest++ = UIntToGrayValue(tempColor, grayPower);
                }
            }

            dest.UnlockBits(bmDest);
            image.UnlockBits(bmSrc);

            return dest;
        }

        //tworzenie siatki z grafik o rozmiarze size
        public unsafe Bitmap CreateGrid(Bitmap image, int amount)
        {
            Bitmap dest = new Bitmap(320, 320, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            BitmapData bmSrc = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadOnly, dest.PixelFormat);
            BitmapData bmDest = dest.LockBits(new Rectangle(Point.Empty, dest.Size), ImageLockMode.WriteOnly, dest.PixelFormat);

            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();
            UInt32* ptrDest = (UInt32*)bmDest.Scan0.ToPointer();

            UInt32 tempColor;

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    tempColor = *(ptrSrc + x + y * image.Width);

                    for (int row = 0; row < amount; ++row)
                    {
                        for (int col = 0; col < amount; ++col)
                        {
                            for(int w = 0; w < gridPixelSize; ++w)
                            {
                                for(int h = 0; h < gridPixelSize; ++h)
                                {
                                    //*(ptrDest + row * image.Width + x + col * image.Height * dest.Width + y * dest.Width) = tempColor;
                                    *(ptrDest + row * image.Width * gridPixelSize + x * gridPixelSize + w + 
                                        col * image.Height * gridPixelSize * dest.Width + y * gridPixelSize * dest.Width + h * dest.Width) = tempColor;
                                }
                            }
                            
                        }
                    }

                }
            }

            dest.UnlockBits(bmDest);
            image.UnlockBits(bmSrc);

            return dest;
        }
    }
}