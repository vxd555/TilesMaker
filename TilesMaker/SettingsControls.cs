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
        //zmiana typu szarości
        private void ChangeGrayValue(object sender, EventArgs e)
        {
            if (GrayMaskedText.Text.Length > 0)
            {
                int tempGray = Int32.Parse(GrayMaskedText.Text);
                if (tempGray > 100) return;

                if (tempGray == 100)
                {
                    grayScaleValue = 1;
                }
                else if (tempGray == 0)
                {
                    grayScaleValue = 0;
                }
                else
                {
                    grayScaleValue = float.Parse(GrayMaskedText.Text) / 100f;
                }
                RefreshGrayView();
            }
        }

        //zmiana typu zapisu grafiki
        private void SaveBothRadio_CheckedChanged(object sender, EventArgs e)
        {
            saveType = 0;
        }
        private void SaveColorRadio_CheckedChanged(object sender, EventArgs e)
        {
            saveType = 1;
        }
        private void SaveGrayRadio_CheckedChanged(object sender, EventArgs e)
        {
            saveType = 2;
        }
        //--

        private void IncreaseImage_Click(object sender, EventArgs e)
        {
            if (newImageSize == 32) newImageSize = 64;
            else if (newImageSize == 16) newImageSize = 32;
            else if (newImageSize == 8) newImageSize = 16;
            else if (newImageSize == 4) newImageSize = 8;

            SizeImageLabel.Text = newImageSize.ToString();
        }

        private void DecreaseImage_Click(object sender, EventArgs e)
        {
            if (newImageSize == 64) newImageSize = 32;
            else if (newImageSize == 32) newImageSize = 16;
            else if (newImageSize == 16) newImageSize = 8;
            else if (newImageSize == 8) newImageSize = 4;

            SizeImageLabel.Text = newImageSize.ToString();
        }
    }
}

