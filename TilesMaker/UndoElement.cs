using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilesMaker
{
    public enum TransformType
    {
        drawPixels = 0,
        rotateLeft = 1,
        rotateRight = 2,
        mirrorHorizontal = 3,
        mirrorVertical = 4,
        shiftLeft = 5,
        shiftRight = 6,
        shiftUp = 7,
        shiftDown = 8,
        drawLine = 9,
        drawRect = 10,
        drawCircle = 11
    };

    class UndoElement
    {
        public List<TilesPixel> TilesPixels;
        public int transform;

        public UndoElement()
        {

        }
    }
}
