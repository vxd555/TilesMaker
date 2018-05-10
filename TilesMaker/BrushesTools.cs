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
        //zmiana kolorów guzików
        private void OffAllButtons()
        {
            BrushPixelButton.BackColor = Color.FromArgb(230, 230, 230);
            BrushLineButton.BackColor = Color.FromArgb(230, 230, 230);
            BrushFillButton.BackColor = Color.FromArgb(230, 230, 230);
            BrushSquareButton.BackColor = Color.FromArgb(230, 230, 230);
            BrushCircleButton.BackColor = Color.FromArgb(230, 230, 230);
        }

        //włączenie typu guzików
        private void BrushPixelButton_Click(object sender, EventArgs e)
        {
            SetBrush(0);
        }
        private void BrushLineButton_Click(object sender, EventArgs e)
        {
            SetBrush(1);
        }
        private void BrushFillButton_Click(object sender, EventArgs e)
        {
            SetBrush(2);
        }
        private void BrushSquareButton_Click(object sender, EventArgs e)
        {
            SetBrush(3);
        }
        private void BrushCircleButton_Click(object sender, EventArgs e)
        {
            SetBrush(4);
        }
        private void SetBrush(int type)
        {
            brushType = type;
            OffAllButtons();
            if (type == 0) BrushPixelButton.BackColor = Color.FromArgb(170, 170, 170);
            else if (type == 1) BrushLineButton.BackColor = Color.FromArgb(170, 170, 170);
            else if (type == 2) BrushFillButton.BackColor = Color.FromArgb(170, 170, 170);
            else if (type == 3) BrushSquareButton.BackColor = Color.FromArgb(170, 170, 170);
            else if (type == 4) BrushCircleButton.BackColor = Color.FromArgb(170, 170, 170);
        }
        //--

        //cofnij działanie na obrazku
        private void UndoButton_Click(object sender, EventArgs e)
        {
            undo.Undo();
        }
        //--

        //ponów działanie na obrazku
        private void RedoButton_Click(object sender, EventArgs e)
        {
            undo.Redo();
        }
        //--

        //obróć w lewo
        private void RootLeft_Click(object sender, EventArgs e)
        {
            RotL();
        }

        public void RotL()
        {
            sourcePicture.RotateFlip(RotateFlipType.Rotate270FlipNone);
            RefreshImageView();

            undo.CreateUndo(TransformType.rotateLeft);
        }

        //obróć w prawo
        private void RootRight_Click(object sender, EventArgs e)
        {
            RotR();
        }

        public void RotR()
        {
            sourcePicture.RotateFlip(RotateFlipType.Rotate90FlipNone);
            RefreshImageView();

            undo.CreateUndo(TransformType.rotateRight);
        }

        //odbicie lustrzane horyzontalne
        private void HorMirrorButton_Click(object sender, EventArgs e)
        {
            MirrH();
        }

        public void MirrH()
        {
            sourcePicture.RotateFlip(RotateFlipType.RotateNoneFlipX);
            RefreshImageView();

            undo.CreateUndo(TransformType.mirrorHorizontal);
        }

        //odbicie lustrzane wertykalne
        private void VerMirrorButton_Click(object sender, EventArgs e)
        {
            MirrV();
        }

        public void MirrV()
        {
            sourcePicture.RotateFlip(RotateFlipType.RotateNoneFlipY);
            RefreshImageView();

            undo.CreateUndo(TransformType.mirrorVertical);
        }

        // gloabal size  scale     amount
        //   4          1 - 80  80x40x20x10x5
        //   8          1 - 40    40x20x10x5
        //  16          1 - 20     20x10x5
        //  32          1 - 10      10x5
        //  64          1 - 5        5
        //zminiejszenie głównego obrazu
        private void LupeMinusButton_Click(object sender, EventArgs e)
        {
            if (scale > 1)
            {
                --scale;
                RefreshMainImage();
                RefreshLabels();
            }
        }

        //zwiększenie głównego obrazu
        private void LupePlusButton_Click(object sender, EventArgs e)
        {
            if (globalSize == 64)
            {
                if (scale < 5)
                {
                    ++scale;
                    RefreshMainImage();
                    RefreshLabels();
                }
            }
            else if (globalSize == 32)
            {
                if (scale < 10)
                {
                    ++scale;
                    RefreshMainImage();
                    RefreshLabels();
                }
            }
            else if (globalSize == 16)
            {
                if (scale < 20)
                {
                    ++scale;
                    RefreshMainImage();
                    RefreshLabels();
                }
            }
            else if (globalSize == 8)
            {
                if (scale < 40)
                {
                    ++scale;
                    RefreshMainImage();
                    RefreshLabels();
                }
            }
            else if (globalSize == 4)
            {
                if (scale < 80)
                {
                    ++scale;
                    RefreshMainImage();
                    RefreshLabels();
                }
            }

        }

        //pomniejszenie obrazków na siatce
        //oraz ustalanie jakiej szerokości na siatce odpowiada jeden pixel z grafiki
        private void SizeMinusButton_Click(object sender, EventArgs e)
        {
            if (globalSize == 32)
            {
                if (gridScale == 5)
                {
                    gridScale = 10;
                    gridPixelSize = 1;
                }

            }
            else if (globalSize == 16)
            {
                if (gridScale == 10)
                {
                    gridScale = 20;
                    gridPixelSize = 1;
                }
                else if (gridScale == 5)
                {
                    gridScale = 10;
                    gridPixelSize = 2;
                }
            }
            else if (globalSize == 8)
            {
                if (gridScale == 20)
                {
                    gridScale = 40;
                    gridPixelSize = 1;
                }
                else if (gridScale == 10)
                {
                    gridScale = 20;
                    gridPixelSize = 2;
                }
                else if (gridScale == 5)
                {
                    gridScale = 10;
                    gridPixelSize = 4;
                }
            }
            else if (globalSize == 4)
            {
                if (gridScale == 40)
                {
                    gridScale = 80;
                    gridPixelSize = 1;
                }
                else if (gridScale == 20)
                {
                    gridScale = 40;
                    gridPixelSize = 2;
                }
                else if (gridScale == 10)
                {
                    gridScale = 20;
                    gridPixelSize = 4;
                }
                else if (gridScale == 5)
                {
                    gridScale = 10;
                    gridPixelSize = 8;
                }
            }
            RefreshGridImage();
            RefreshLabels();
        }
        //powiekszenie obrazków na siatce
        private void SizePlusButton_Click(object sender, EventArgs e)
        {
            if (globalSize == 32)
            {
                if (gridScale == 10)
                {
                    gridScale = 5;
                    gridPixelSize = 2;
                }
            }
            else if (globalSize == 16)
            {
                if (gridScale == 20)
                {
                    gridScale = 10;
                    gridPixelSize = 2;
                }
                else if (gridScale == 10)
                {
                    gridScale = 5;
                    gridPixelSize = 4;
                }
            }
            else if (globalSize == 8)
            {
                if (gridScale == 40)
                {
                    gridScale = 20;
                    gridPixelSize = 2;
                }
                else if (gridScale == 20)
                {
                    gridScale = 10;
                    gridPixelSize = 4;
                }
                else if (gridScale == 10)
                {
                    gridScale = 5;
                    gridPixelSize = 8;
                }
            }
            else if (globalSize == 4)
            {
                if (gridScale == 80)
                {
                    gridScale = 40;
                    gridPixelSize = 2;
                }
                else if (gridScale == 40)
                {
                    gridScale = 20;
                    gridPixelSize = 4;
                }
                else if (gridScale == 20)
                {
                    gridScale = 10;
                    gridPixelSize = 8;
                }
                else if (gridScale == 10)
                {
                    gridScale = 5;
                    gridPixelSize = 16;
                }
            }
            RefreshGridImage();
            RefreshLabels();
        }

        //przesówanie grafiki w lewo o jeden pixel
        private void LeftMoveButton_Click(object sender, EventArgs e)
        {
            ShiftLeft();
        }

        public unsafe void ShiftLeft()
        {
            //blokowanie grafiki
            BitmapData bmSrc = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();

            UInt32[] LeftLine = new UInt32[sourcePicture.Size.Height];
            int tempSize = sourcePicture.Size.Height;

            for (int y = 0; y < tempSize; ++y) //kopiowanie lini z lewej
            {
                LeftLine[y] = *(ptrSrc + y * tempSize);
            }

            for (int x = 0; x < tempSize - 1; ++x) //przesówani grafiki
            {
                for (int y = 0; y < tempSize; ++y)
                {
                    *(ptrSrc + x + y * tempSize) = *(ptrSrc + x + 1 + y * tempSize);
                }
            }

            for (int y = 0; y < tempSize; ++y) //wklejanie lini
            {
                *(ptrSrc + tempSize - 1 + y * tempSize) = LeftLine[y];
            }

            sourcePicture.UnlockBits(bmSrc);
            RefreshImageView();

            undo.CreateUndo(TransformType.shiftLeft);
        }

        //przesówanie grafiki w górę o jeden pixel
        private void UpMoveButton_Click(object sender, EventArgs e)
        {
            ShiftUp();
        }

        public unsafe void ShiftUp()
        {
            //blokowanie grafiki
            BitmapData bmSrc = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();

            UInt32[] LeftLine = new UInt32[sourcePicture.Size.Width];
            int tempSize = sourcePicture.Size.Width;

            for (int x = 0; x < tempSize; ++x) //kopiowanie lini z góry
            {
                LeftLine[x] = *(ptrSrc + x);
            }

            for (int x = 0; x < tempSize; ++x) //przesówani grafiki
            {
                for (int y = 1; y < tempSize; ++y)
                {
                    *(ptrSrc + x + (y - 1) * tempSize) = *(ptrSrc + x + y * tempSize);
                }
            }

            for (int x = 0; x < tempSize; ++x) //wklejanie lini
            {
                *(ptrSrc + x + (tempSize - 1) * tempSize) = LeftLine[x];
            }

            sourcePicture.UnlockBits(bmSrc);
            RefreshImageView();

            undo.CreateUndo(TransformType.shiftUp);
        }

        //przesówanie grafiki w dół o jeden pixel
        private void DownMoveButton_Click(object sender, EventArgs e)
        {
            ShiftDown();
        }

        public unsafe void ShiftDown()
        {
            //blokowanie grafiki
            BitmapData bmSrc = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();

            UInt32[] LeftLine = new UInt32[sourcePicture.Size.Width];
            int tempSize = sourcePicture.Size.Width;

            for (int x = 0; x < tempSize; ++x) //kopiowanie lini z dołu
            {
                LeftLine[x] = *(ptrSrc + x + (tempSize - 1) * tempSize);
            }

            for (int x = 0; x < tempSize; ++x) //przesówani grafiki
            {
                for (int y = tempSize - 1; y > 0; --y)
                {
                    *(ptrSrc + x + y * tempSize) = *(ptrSrc + x + (y - 1) * tempSize);
                }
            }

            for (int x = 0; x < tempSize; ++x) //wklejanie lini
            {
                *(ptrSrc + x) = LeftLine[x];
            }

            sourcePicture.UnlockBits(bmSrc);
            RefreshImageView();

            undo.CreateUndo(TransformType.shiftDown);
        }

        //przesówanie grafiki w prawo o jeden pixel
        private void RightMoveButton_Click(object sender, EventArgs e)
        {
            ShiftRight();
        }

        public unsafe void ShiftRight()
        {
            //blokowanie grafiki
            BitmapData bmSrc = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();

            UInt32[] LeftLine = new UInt32[sourcePicture.Size.Height];
            int tempSize = sourcePicture.Size.Height;

            for (int y = 0; y < tempSize; ++y) //kopiowanie lini z lewej
            {
                LeftLine[y] = *(ptrSrc + tempSize - 1 + y * tempSize);
            }

            for (int x = tempSize - 1; x > 0; --x) //przesówani grafiki
            {
                for (int y = 0; y < tempSize; ++y)
                {
                    *(ptrSrc + x + y * tempSize) = *(ptrSrc + (x - 1) + y * tempSize);
                }
            }

            for (int y = 0; y < tempSize; ++y) //wklejanie lini
            {
                *(ptrSrc + y * tempSize) = LeftLine[y];
            }

            sourcePicture.UnlockBits(bmSrc);
            RefreshImageView();

            undo.CreateUndo(TransformType.shiftRight);
        }
    }
}