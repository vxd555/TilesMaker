using System;
using System.Collections.Generic;

namespace TilesMaker
{
    public class UndoClass
    {
        int undoSize = 32;

        TilesMaker tilesMaker;

        List<UndoElement> undo;
        List<UndoElement> redo;

        UndoElement currUndo;

        public UndoClass(TilesMaker tm)
        {
            undo = new List<UndoElement>();
            redo = new List<UndoElement>();

            tilesMaker = tm;
        }

        public void BeginAddPixel() //rozpoczęcie nowego cofania
        {
            currUndo = new UndoElement();
            currUndo.transform = 0;
            currUndo.TilesPixels = new List<TilesPixel>();
            //tilesMaker.DebugLog("beg");
        }

        public void AddPixelToUndo(int x = 0, int y = 0, UInt32 color = 0) //dodanie konkretnych pikseli do cofania
        {
            //tilesMaker.DebugLog(currUndo.TilesPixels.Count.ToString());
            if (currUndo == null)
            {
                currUndo = new UndoElement();
                currUndo.TilesPixels = new List<TilesPixel>();
            }
            TilesPixel tempPixel = new TilesPixel(x, y, color);
            currUndo.TilesPixels.Add(tempPixel);
        }

        public void SaveUndo()
        {
            if(undo.Count >= undoSize)
            {
                undo.RemoveAt(0);
            }
            undo.Add(currUndo);
        }

        public void CreateUndo(TransformType transformType, int x = 0, int y = 0, int w = 0, int h = 0, UInt32 color = 0)
        {
            UndoElement nextUndo = new UndoElement();
            nextUndo.transform = (int)transformType;

            if(undo.Count >= undoSize)
            {
                undo.RemoveAt(0);
            }

            undo.Add(nextUndo);
        }

        public void Undo()
        {
            if (undo.Count == 0) return;
            tilesMaker.undoPhase = true;

            if (redo.Count >= undoSize)
            {
                redo.RemoveAt(0);
            }
            redo.Add(undo[undo.Count - 1]);

            if (undo[undo.Count - 1].transform == (int)TransformType.drawPixels)
            {
                tilesMaker.DrawPixelFromList(undo[undo.Count - 1].TilesPixels);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.rotateLeft)
            {
                tilesMaker.RotR(false);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.rotateRight)
            {
                tilesMaker.RotL(false);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.mirrorHorizontal)
            {
                tilesMaker.MirrH(false);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.mirrorVertical)
            {
                tilesMaker.MirrV(false);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.shiftLeft)
            {
                tilesMaker.ShiftLeft(false);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.shiftRight)
            {
                tilesMaker.ShiftRight(false);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.shiftUp)
            {
                tilesMaker.ShiftUp(false);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.shiftDown)
            {
                tilesMaker.ShiftDown(false);
            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.drawLine)
            {

            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.drawRect)
            {

            }
            else if (undo[undo.Count - 1].transform == (int)TransformType.drawCircle)
            {

            }

            undo.RemoveAt(undo.Count - 1);
            tilesMaker.undoPhase = false;
        }

        public void Redo()
        {
            if (redo.Count == 0) return;
            tilesMaker.undoPhase = true;

            if (redo[redo.Count - 1].transform == (int)TransformType.drawPixels)
            {

            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.rotateLeft)
            {
                tilesMaker.RotL(false);
            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.rotateRight)
            {
                tilesMaker.RotR(false);
            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.mirrorHorizontal)
            {
                tilesMaker.MirrH(false);
            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.mirrorVertical)
            {
                tilesMaker.MirrV(false);
            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.shiftLeft)
            {
                tilesMaker.ShiftLeft(false);
            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.shiftRight)
            {
                tilesMaker.ShiftRight(false);
            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.shiftUp)
            {
                tilesMaker.ShiftUp(false);
            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.shiftDown)
            {
                tilesMaker.ShiftDown(false);
            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.drawLine)
            {

            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.drawRect)
            {

            }
            else if (redo[redo.Count - 1].transform == (int)TransformType.drawCircle)
            {

            }

            if (undo.Count >= undoSize)
            {
                undo.RemoveAt(0);
            }
            undo.Add(redo[redo.Count - 1]);

            redo.RemoveAt(redo.Count - 1);
            tilesMaker.undoPhase = false;
        }
    }

}
