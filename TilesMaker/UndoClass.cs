using System;
using System.Collections.Generic;

namespace TilesMaker
{
    public class UndoClass
    {
        int undoSize = 32;

        List<UndoElement> undo;
        List<UndoElement> redo;

        public UndoClass()
        {
            undo = new List<UndoElement>();
            redo = new List<UndoElement>();
        }

        public void CreateUndo(TransformType transformType, int x = 0, int y = 0, int w = 0, int h = 0, UInt32 color = 0)
        {

        }

        public void Undo()
        {

        }

        public void Redo()
        {

        }
    }

}
