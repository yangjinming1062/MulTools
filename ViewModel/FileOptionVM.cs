using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MulTools.ViewModel
{
    class FileOptionVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region 数据绑定
        private bool isRecursive = true;
        public bool IsRecursive
        {
            get => isRecursive;
            set
            {
                isRecursive = value;
                NotifyPropertyChanged("IsRecursive");
            }
        }

        private string directoryPath;
        public string DirectoryPath
        {
            get => directoryPath;
            set
            {
                directoryPath = value;
                NotifyPropertyChanged("DirectoryPath");
                BuildFiles();
            }
        }
        private bool isShowOptions = false;
        public bool IsShowOptions
        {
            get => isShowOptions;
            set
            {
                isShowOptions = value;
                NotifyPropertyChanged("IsShowOptions");
            }
        }

        private bool compared = false;
        public bool Compared
        {
            get => compared;
            set
            {
                compared = value;
                NotifyPropertyChanged("Compared");
            }
        }

        private bool allExpanded = true;
        public bool AllExpanded
        {
            get => allExpanded;
            set
            {
                allExpanded = value;
                NotifyPropertyChanged("AllExpanded");
            }
        }

        private string replaceSource;
        public string ReplaceSource
        {
            get => replaceSource;
            set
            {
                replaceSource = value;
                NotifyPropertyChanged("ReplaceSource");
            }
        }

        private string replaceTarget;
        public string ReplaceTarget
        {
            get => replaceTarget;
            set
            {
                replaceTarget = value;
                NotifyPropertyChanged("ReplaceTarget");
            }
        }

        public ObservableCollection<FileShowInfo> ShowFiles { get; set; } = new ObservableCollection<FileShowInfo>();
        #endregion
    }
}
