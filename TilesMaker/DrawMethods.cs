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
        //wątek odpowiedzialny za rysowanie
        public void Drawer(object data)
        {
            for (;;)
            {
                if (undoPhase || dumpLock) continue; //gdy obraz jest właśnie zmieniany przez cofanie lub ponawianie jest na chwile blokowany 

                if (leftBrush)
                {
                    //zabezpieczenie przed wyjściem z tablicy
                    if (mousePosX < globalSize * scale && mousePosX > 0 && mousePosY < globalSize * scale && mousePosY > 0)
                    {
                        if (brushType == 0) //rysowanie pojedyńczym pikselem
                        {
                            Draw(mousePosX, mousePosY, RandomColor(0));
                        }
                        else if (brushType == 1) //rysowanie lini
                        {
                            LineDraw(mousePosX, mousePosY, 0);
                        }
                        else if (brushType == 2) //kubełek z wypełnieniem
                        {
                            MultiDraw(mousePosX, mousePosY, 0);
                        }
                        else if (brushType == 3) //rysowanie prostokąta
                        {
                            RectangleDraw(mousePosX, mousePosY, 0);
                        }
                        else if (brushType == 4) //rysowanie elipsy
                        {
                            EllipseDraw(mousePosX, mousePosY, 0);
                        }
                    }
                }
                else if (rightBrush)
                {
                    //if (lastScalePosY != (mousePosY / scale))
                    if (mousePosX < globalSize * scale && mousePosX > 0 && mousePosY < globalSize * scale && mousePosY > 0)
                    {
                        if (brushType == 0) //rysowanie pojedyńczym pikselem
                        {
                            Draw(mousePosX, mousePosY, RandomColor(1));
                        }
                        else if (brushType == 1) //rysowanie lini
                        {
                            LineDraw(mousePosX, mousePosY, 1);
                        }
                        else if (brushType == 2) //kubełek z wypełnieniem
                        {
                            MultiDraw(mousePosX, mousePosY, 1);
                        }
                        else if (brushType == 3) //rysowanie kwadratu
                        {
                            RectangleDraw(mousePosX, mousePosY, 1);
                        }
                        else if (brushType == 4) //rysowanie elipsy
                        {
                            EllipseDraw(mousePosX, mousePosY, 1);
                        }
                    }
                }

                if (endDrawLine) //po zakończeniu rysowania bardziej skomplikowanych elementów niż pixel
                {
                    RefreshShape(mousePosX, mousePosY, 1);
                }
            }
        }

        //rozpoczęcie rysowania gdy przytrzyma się przycisk
        private unsafe void BeginDraw(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) //pobieranie koloru z obrazka
                {
                    Color tempColor = sourcePicture.GetPixel(e.X / scale, e.Y / scale);
                    palette.SetPixel(brushIndex.ElementAt(0), 0, tempColor);
                    brushColor[brushIndex.ElementAt(0)] = ColorToUint32(tempColor);
                    DrawColorSelector();
                }
                else
                {
                    if (brushType == 1 || brushType == 3 || brushType == 4)
                    {
                        if (startDrawPosX == -1 && startDrawPosY == -1)
                        {
                            startDrawPosX = e.X / scale;
                            startDrawPosY = e.Y / scale;
                            endDrawLine = false;
                        }
                    }
                    undo.BeginAddPixel();
                    leftBrush = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) //pobieranie koloru z obrazka
                {
                    Color tempColor = sourcePicture.GetPixel(e.X / scale, e.Y / scale);
                    palette.SetPixel(brushAltIndex.ElementAt(0), 0, tempColor);
                    brushColor[brushAltIndex.ElementAt(0)] = ColorToUint32(tempColor);
                    DrawColorSelector();
                }
                else
                {
                    if (brushType == 1 || brushType == 3 || brushType == 4)
                    {
                        if (startDrawPosX == -1 && startDrawPosY == -1)
                        {
                            startDrawPosX = e.X / scale;
                            startDrawPosY = e.Y / scale;
                            endDrawLine = false;
                        }
                    }
                    undo.BeginAddPixel();
                    rightBrush = true;
                }
            }
        }

        //koniec rysowania gdy puści się klawisz od rysowania
        private void EndDraw(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftBrush = false;
                undo.SaveUndo();
                if (brushType == 1 || brushType == 3 || brushType == 4)
                {
                    endDrawLine = true;
                }

            }
            else if (e.Button == MouseButtons.Right)
            {
                rightBrush = false;
                undo.SaveUndo();
                if (brushType == 1 || brushType == 3 || brushType == 4)
                {
                    endDrawLine = true;
                }
            }
        }

        //spisanie pozycji myszki
        private void SetMousePosition(object sender, MouseEventArgs e)
        {
            mousePosX = e.X;
            mousePosY = e.Y;
        }

        //rysowanie pojedyńczego piksela na wszystkich obrazkach
        public unsafe void Draw(int x, int y, UInt32 brushCol)
        {
            int posX = (x / scale);
            int posY = (y / scale);

            if (sourcePicture.GetPixel(posX, posY) == Color.FromArgb((int)brushCol)) return;
            if (lastScalePosX == x / 10 && lastScalePosY == y / 10) return;
            lastScalePosX = x / 10;
            lastScalePosY = y / 10;

            UInt32 tempColor = brushCol;

            BitmapData bmSrc = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();

            undo.AddPixelToUndo(posX, posY + 1, *(ptrSrc + posX + sourcePicture.Width * posY)); //zapisywanie starych kolorów
            *(ptrSrc + posX + sourcePicture.Width * posY) = brushCol;

            sourcePicture.UnlockBits(bmSrc);

            Bitmap dest = (Bitmap)MainImage.Image;
            Bitmap grayDest = (Bitmap)GrayImage.Image;

            BitmapData bmDest = dest.LockBits(new Rectangle(Point.Empty, dest.Size), ImageLockMode.WriteOnly, dest.PixelFormat);
            BitmapData bmGray = grayDest.LockBits(new Rectangle(Point.Empty, grayDest.Size), ImageLockMode.WriteOnly, grayDest.PixelFormat);

            UInt32* ptrDest = (UInt32*)bmDest.Scan0.ToPointer();
            UInt32* ptrGray = (UInt32*)bmGray.Scan0.ToPointer();

            for (int col = 0; col < scale; ++col) //rysowanie na dużych
            {
                for (int row = 0; row < scale; ++row)
                {
                    *(ptrDest + col + posX * scale + row * dest.Width + dest.Width * posY * scale) = tempColor;
                    *(ptrGray + col + posX * scale + row * dest.Width + dest.Width * posY * scale) = UIntToGrayValue(tempColor, grayScaleValue);
                }
            }

            dest.UnlockBits(bmDest);
            grayDest.UnlockBits(bmGray);


            Bitmap gridDest = (Bitmap)ColorGrid.Image;
            Bitmap gridGrayDest = (Bitmap)GrayGrid.Image;

            BitmapData bmGrid = gridDest.LockBits(new Rectangle(Point.Empty, gridDest.Size), ImageLockMode.WriteOnly, gridDest.PixelFormat);
            BitmapData bmGrGr = gridGrayDest.LockBits(new Rectangle(Point.Empty, gridGrayDest.Size), ImageLockMode.WriteOnly, gridGrayDest.PixelFormat);

            UInt32* ptrGrid = (UInt32*)bmGrid.Scan0.ToPointer();
            UInt32* ptrGrGr = (UInt32*)bmGrGr.Scan0.ToPointer();

            int smallSize = sourcePicture.Width;

            for (int row = 0; row < gridScale; ++row)
            {
                for (int col = 0; col < gridScale; ++col)
                {
                    for (int w = 0; w < gridPixelSize; ++w)
                    {
                        for (int h = 0; h < gridPixelSize; ++h)
                        {
                            *(ptrGrid + row * globalSize * gridPixelSize + posX * gridPixelSize + w +
                                col * globalSize * gridPixelSize * dest.Width + posY * gridPixelSize * dest.Width + h * dest.Width) = tempColor;
                            *(ptrGrGr + row * globalSize * gridPixelSize + posX * gridPixelSize + w +
                                col * globalSize * gridPixelSize * dest.Width + posY * gridPixelSize * dest.Width + h * dest.Width) = UIntToGrayValue(tempColor, grayScaleValue);
                        }
                    }

                }
            }

            gridDest.UnlockBits(bmGrid);
            gridGrayDest.UnlockBits(bmGrGr);

            MainImage.Image = dest;
            GrayImage.Image = grayDest;
            ColorGrid.Image = gridDest;
            GrayGrid.Image = gridGrayDest;

        }

        //odświerzenie lini po narysowaniu
        public unsafe void RefreshShape(int x, int y, int brType)
        {
            sourcePicture = new Bitmap(shapePicture);

            mainPicture = new Bitmap(globalSize * scale, globalSize * scale, PixelFormat.Format32bppPArgb);
            mainPicture = ChangeSize(sourcePicture, scale);

            GrayImage.Image = ImageToGray(mainPicture, grayScaleValue);
            MainImage.Image = mainPicture;
            RefreshGridImage();

            startDrawPosX = -1;
            startDrawPosY = -1;
            endDrawLine = false;
        }

        //rysowanie linii
        public unsafe void LineDraw(int x, int y, int brType)
        {
            int posX = (x / scale);
            int posY = (y / scale);

            if (startDrawPosX == -1 || startDrawPosY == -1) return;
            if (lastScalePosX == x / scale && lastScalePosY == y / scale) return;
            lastScalePosX = x / scale;
            lastScalePosY = y / scale;

            shapePicture = new Bitmap(sourcePicture);

            Pen pen = new Pen(Color.FromArgb((int)RandomColor(brType)), 1);
            using (var graphics = Graphics.FromImage(shapePicture))
            {
                graphics.DrawLine(pen, startDrawPosX, startDrawPosY, posX, posY);
            }

            mainPicture = new Bitmap(globalSize * scale, globalSize * scale, PixelFormat.Format32bppPArgb);
            mainPicture = ChangeSize(shapePicture, scale);

            //odświerzanie widoku
            if (realTimeOverview) GrayImage.Image = ImageToGray(mainPicture, grayScaleValue);
            MainImage.Image = mainPicture;
            if (realTimeOverview) ColorGrid.Image = CreateGrid(shapePicture, gridScale);
            if (realTimeOverview) GrayGrid.Image = CreateGrid(ImageToGray(shapePicture, grayScaleValue), gridScale);
        }

        //rysowanie prostokąta
        public unsafe void RectangleDraw(int x, int y, int brType)
        {
            int posX = (x / scale);
            int posY = (y / scale);

            if (startDrawPosX == -1 || startDrawPosY == -1) return;
            if (lastScalePosX == x / scale && lastScalePosY == y / scale) return;
            lastScalePosX = x / scale;
            lastScalePosY = y / scale;

            shapePicture = new Bitmap(sourcePicture);

            Pen pen = new Pen(Color.FromArgb((int)RandomColor(brType)), 1);
            if(posX < startDrawPosX)
            {
                if (posY < startDrawPosY)
                {
                    using (var graphics = Graphics.FromImage(shapePicture))
                    {
                        graphics.DrawRectangle(pen, posX, posY, startDrawPosX - posX, startDrawPosY - posY);
                    }
                }
                else
                {
                    using (var graphics = Graphics.FromImage(shapePicture))
                    {
                        graphics.DrawRectangle(pen, posX, startDrawPosY, startDrawPosX - posX, posY - startDrawPosY);
                    }
                }
            }
            else
            {
                if (posY < startDrawPosY)
                {
                    using (var graphics = Graphics.FromImage(shapePicture))
                    {
                        graphics.DrawRectangle(pen, startDrawPosX, posY, posX - startDrawPosX, startDrawPosY - posY);
                    }
                }
                else
                {
                    using (var graphics = Graphics.FromImage(shapePicture))
                    {
                        graphics.DrawRectangle(pen, startDrawPosX, startDrawPosY, posX - startDrawPosX, posY - startDrawPosY);
                    }
                }
            }

            mainPicture = new Bitmap(globalSize * scale, globalSize * scale, PixelFormat.Format32bppPArgb);
            mainPicture = ChangeSize(shapePicture, scale);

            //odświerzanie widoku
            if (realTimeOverview) GrayImage.Image = ImageToGray(mainPicture, grayScaleValue);
            MainImage.Image = mainPicture;
            if (realTimeOverview) ColorGrid.Image = CreateGrid(shapePicture, gridScale);
            if (realTimeOverview) GrayGrid.Image = CreateGrid(ImageToGray(shapePicture, grayScaleValue), gridScale);
        }

        //rysowanie kółek
        public unsafe void EllipseDraw(int x, int y, int brType)
        {
            int posX = (x / scale);
            int posY = (y / scale);

            if (startDrawPosX == -1 || startDrawPosY == -1) return;
            if (lastScalePosX == x / scale && lastScalePosY == y / scale) return;
            lastScalePosX = x / scale;
            lastScalePosY = y / scale;

            shapePicture = new Bitmap(sourcePicture);

            Pen pen = new Pen(Color.FromArgb((int)RandomColor(brType)), 1);
            if (posX < startDrawPosX)
            {
                if (posY < startDrawPosY)
                {
                    using (var graphics = Graphics.FromImage(shapePicture))
                    {
                        graphics.DrawEllipse(pen, posX, posY, startDrawPosX - posX, startDrawPosY - posY);
                    }
                }
                else
                {
                    using (var graphics = Graphics.FromImage(shapePicture))
                    {
                        graphics.DrawEllipse(pen, posX, startDrawPosY, startDrawPosX - posX, posY - startDrawPosY);
                    }
                }
            }
            else
            {
                if (posY < startDrawPosY)
                {
                    using (var graphics = Graphics.FromImage(shapePicture))
                    {
                        graphics.DrawEllipse(pen, startDrawPosX, posY, posX - startDrawPosX, startDrawPosY - posY);
                    }
                }
                else
                {
                    using (var graphics = Graphics.FromImage(shapePicture))
                    {
                        graphics.DrawEllipse(pen, startDrawPosX, startDrawPosY, posX - startDrawPosX, posY - startDrawPosY);
                    }
                }
            }


            mainPicture = new Bitmap(globalSize * scale, globalSize * scale, PixelFormat.Format32bppPArgb);
            mainPicture = ChangeSize(shapePicture, scale);

            if(realTimeOverview) GrayImage.Image = ImageToGray(mainPicture, grayScaleValue);
            MainImage.Image = mainPicture;
            if (realTimeOverview) ColorGrid.Image = CreateGrid(shapePicture, gridScale);
            if (realTimeOverview) GrayGrid.Image = CreateGrid(ImageToGray(shapePicture, grayScaleValue), gridScale);
        }

        //wypełnianie powierzchni
        public unsafe void MultiDraw(int x, int y, int brType)
        {
            int posX = (x / scale);
            int posY = (y / scale);

            //if (sourcePicture.GetPixel(posX, posY) == Color.FromArgb((int)brushCol)) return;
            if (lastScalePosX == x / scale && lastScalePosY == y / scale) return;
            lastScalePosX = x / scale;
            lastScalePosY = y / scale;

            int[,] partentTable = new int[globalSize, globalSize]; //tablica odwiedzonych pixeli
            for (int col = 0; col < partentTable.GetLength(0); ++col)
            {
                for (int row = 0; row < partentTable.GetLength(1); ++row)
                {
                    partentTable[col, row] = 0;
                }
            }

            UInt32 tempColor = RandomColor(brType);

            BitmapData bmPicture = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            UInt32* ptrPicture = (UInt32*)bmPicture.Scan0.ToPointer();

            UInt32 getColor = *(ptrPicture + posX + posY * globalSize); //kolor który będzie przerabiany

            multiQueue.Clear();
            multiQueue.Enqueue(new Point(posX, posY));
            *(ptrPicture + posX + posY * globalSize) = tempColor;
            partentTable[posX, posY] = 1;

            Point tempNode = new Point(0, 0);

            for (; multiQueue.Count > 0;) //wyłapywanie kolejnych pól i ich kolorowanie
            {
                tempNode = multiQueue.Peek();
                if (tempNode.Y > 0)
                {
                    if (partentTable[tempNode.X, tempNode.Y - 1] == 0)
                    {
                        if (getColor == *(ptrPicture + tempNode.X + (tempNode.Y - 1) * globalSize))
                        {
                            multiQueue.Enqueue(new Point(tempNode.X, tempNode.Y - 1));
                            *(ptrPicture + tempNode.X + (tempNode.Y - 1) * globalSize) = RandomColor(brType);
                            partentTable[tempNode.X, tempNode.Y - 1] = 1;
                        }
                    }
                }
                if (tempNode.Y < globalSize - 1)
                {
                    if (partentTable[tempNode.X, tempNode.Y + 1] == 0)
                    {
                        if (getColor == *(ptrPicture + tempNode.X + (tempNode.Y + 1) * globalSize))
                        {
                            multiQueue.Enqueue(new Point(tempNode.X, tempNode.Y + 1));
                            *(ptrPicture + tempNode.X + (tempNode.Y + 1) * globalSize) = RandomColor(brType);
                            partentTable[tempNode.X, tempNode.Y + 1] = 1;
                        }
                    }
                }
                if (tempNode.X > 0)
                {
                    if (partentTable[tempNode.X - 1, tempNode.Y] == 0)
                    {
                        if (getColor == *(ptrPicture + tempNode.X - 1 + tempNode.Y * globalSize))
                        {
                            multiQueue.Enqueue(new Point(tempNode.X - 1, tempNode.Y));
                            *(ptrPicture + (tempNode.X - 1) + tempNode.Y * globalSize) = RandomColor(brType);
                            partentTable[(tempNode.X - 1), tempNode.Y] = 1;
                        }
                    }
                }
                if (tempNode.X < globalSize - 1)
                {
                    if (partentTable[tempNode.X + 1, tempNode.Y] == 0)
                    {
                        if (getColor == *(ptrPicture + tempNode.X + 1 + (tempNode.Y) * globalSize))
                        {
                            multiQueue.Enqueue(new Point(tempNode.X + 1, tempNode.Y));
                            *(ptrPicture + tempNode.X + 1 + tempNode.Y * globalSize) = RandomColor(brType);
                            partentTable[tempNode.X + 1, tempNode.Y] = 1;
                        }
                    }
                }
                multiQueue.Dequeue();
            }

            sourcePicture.UnlockBits(bmPicture);

            mainPicture = new Bitmap(globalSize * scale, globalSize * scale, PixelFormat.Format32bppPArgb);
            mainPicture = ChangeSize(sourcePicture, scale);

            GrayImage.Image = ImageToGray(mainPicture, grayScaleValue);
            MainImage.Image = mainPicture;
            RefreshGridImage();
        }

        //wypełnianie pikseli z listy
        public unsafe void DrawPixelFromList(List<TilesPixel> pixelList)
        {
            if (pixelList.Count == 0) return;

            BitmapData bmPicture = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            UInt32* ptrPicture = (UInt32*)bmPicture.Scan0.ToPointer();

            for(int el = 0; el < pixelList.Count; ++el)
            {
                *(ptrPicture + pixelList[el].posX + (pixelList[el].posY - 1) * globalSize) = pixelList[el].color;
            }

            sourcePicture.UnlockBits(bmPicture);

            mainPicture = new Bitmap(globalSize * scale, globalSize * scale, PixelFormat.Format32bppPArgb);
            mainPicture = ChangeSize(sourcePicture, scale);

            GrayImage.Image = ImageToGray(mainPicture, grayScaleValue);
            MainImage.Image = mainPicture;
            RefreshGridImage();
        }

        //wypełnianie pikseli z listy kolorów
        public unsafe void DrawPixelFromColorList(List<UInt32> pixelList)
        {
            if (pixelList.Count == 0) return;

            globalSize = (int)pixelList[0];

            newImageSize = globalSize;
            sourcePicture = new Bitmap(newImageSize, newImageSize);
            BitmapData bmPicture = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            UInt32* ptrPicture = (UInt32*)bmPicture.Scan0.ToPointer();

            pixelList.RemoveAt(0);
            for (int py = 0; py < globalSize; ++py)
            {
                for (int px = 0; px < globalSize; ++px)
                {
                    *(ptrPicture + px + (py) * globalSize) = pixelList[px * globalSize + py];
                }
            }

            sourcePicture.UnlockBits(bmPicture);

            mainPicture = new Bitmap(globalSize * scale, globalSize * scale, PixelFormat.Format32bppPArgb);
            mainPicture = ChangeSize(sourcePicture, scale);

            GrayImage.Image = ImageToGray(mainPicture, grayScaleValue);
            MainImage.Image = mainPicture;
            RefreshGridImage();
        }
    }
}