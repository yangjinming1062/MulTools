using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class FileShowInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public string FilePath { get; set; }

        private string fileName;
        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                NotifyPropertyChanged("FileName");
            }
        }
        public string FileType { get; set; }
        public string FileSize { get; set; }
        public string FileAddInfo { get; set; }
        public string FullName { get; set; }

        private bool notSame = false;
        public bool NotSame
        {
            get => notSame;
            set
            {
                notSame = value;
                NotifyPropertyChanged("NotSame");
            }
        }
    }
}
