using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;

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
        private Visibility isShowOptions = Visibility.Collapsed;
        public Visibility IsShowOptions
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

        public void BuildFiles()
        {
            ShowFiles.Clear();
            if(Directory.Exists(DirectoryPath))
            {
                BuildFiles(DirectoryPath);
            }
            IsShowOptions = ShowFiles.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
        }
        private void BuildFiles(string DirPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DirPath);
            try
            {
                foreach (FileSystemInfo file in dirInfo.GetFileSystemInfos())
                {
                    if (file.Attributes == FileAttributes.Directory || string.IsNullOrEmpty(file.Extension))
                    {
                        if (IsRecursive)
                        {
                            BuildFiles(file.FullName);
                        }
                    }
                    else
                    {
                        FileShowInfo fileShowInfo = new FileShowInfo();
                        fileShowInfo.FullName = file.FullName;
                        fileShowInfo.FileName = Path.GetFileNameWithoutExtension(file.FullName);
                        fileShowInfo.FileType = file.Extension;
                        fileShowInfo.FileSize = ConvertSize(((FileInfo)file).Length);
                        fileShowInfo.FilePath = Path.GetRelativePath(DirectoryPath, ((FileInfo)file).DirectoryName);
                        if (fileShowInfo.FilePath == ".")
                            fileShowInfo.FilePath = "";
                        ShowFiles.Add(fileShowInfo);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private string ConvertSize(long size)
        {
            if (size > 1024)
            {
                long kb = size / 1024;
                if (kb > 1024)
                {
                    long mb = kb / 1024;
                    return mb.ToString("F2") + "MB";
                }
                else
                {
                    return kb.ToString("F2") + "KB";
                }
            }
            else
            {
                return size.ToString() + "字节";
            }
        }
    }
}
