using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Ink;

namespace MulTools
{
    public enum DrawMode
    {
        None = 0,
        Select,
        Pen,
        Text,
        Line,
        Arrow,
        Rectangle,
        Circle,
        Ray,
        Erase
    }
    public enum StrokesHistoryNodeType
    {
        Removed,
        Added
    }
    public enum ColorPickerButtonSize
    {
        Small,
        Middle,
        Large
    }
    internal class StrokesHistoryNode
    {
        public StrokeCollection Strokes { get; private set; }
        public StrokesHistoryNodeType Type { get; private set; }

        public StrokesHistoryNode(StrokeCollection strokes, StrokesHistoryNodeType type)
        {
            Strokes = strokes;
            Type = type;
        }
    }

    public class FileShowInfo
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
        public string FileAddInfo { get; set; }
    }
}
