using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilesMaker
{
    class TilesPixel
    {
        public int posX;
        public int posY;
        public UInt32 color;

        public TilesPixel()
        {

        }

        public TilesPixel(int x, int y, UInt32 col)
        {
            posX = x;
            posY = y;
            color = col;
        }

        public byte[] PixelToByteArray()
        {
            byte[] pxb = BitConverter.GetBytes(posX);
            byte[] pyb = BitConverter.GetBytes(posY);
            byte[] colb = BitConverter.GetBytes(color);

            byte[] info = new byte[12];

            System.Buffer.BlockCopy(pxb, 0, info, 0, 4);
            System.Buffer.BlockCopy(pyb, 0, info, 4, 4);
            System.Buffer.BlockCopy(colb, 0, info, 8, 4);

            return info;
        }
    }
}
