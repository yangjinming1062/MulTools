using MulTools.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace MulTools.UC
{
    /// <summary>
    /// FileOption.xaml 的交互逻辑
    /// </summary>
    public partial class FileOption : UserControl
    {
        #region 变量
        private string currentSort = "FilePath";
        private CollectionViewSource cvsList;
        private int Samefilter = 0;
        internal FileOptionVM viewModel { get; } = new FileOptionVM();
        private FileOptionVM otherVM;
        #endregion

        public FileOption()
        {
            InitializeComponent();
            DataContext = viewModel;
            cvsList = (CollectionViewSource)this.Resources["cvsList"];
            cvsList.GroupDescriptions.Add(new PropertyGroupDescription(currentSort));
        }

        private void UC_Loaded(object sender, RoutedEventArgs e)
        {
            var parentGrid = this.Parent as Grid;
            foreach (var uc in parentGrid.Children)
            {
                if (uc is FileOption fo && fo != this)
                {
                    otherVM = fo.viewModel;
                    break;
                }
            }
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                viewModel.DirectoryPath = folderBrowserDialog.SelectedPath;
            }
        }

        #region 过滤
        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            Samefilter = (sender as Button).Content.ToString() == "相同" ? 1 : -1;
            CollectionViewSource.GetDefaultView(dataGrid.ItemsSource).Refresh();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Samefilter = 0;//文本框搜索
            CollectionViewSource.GetDefaultView(dataGrid.ItemsSource).Refresh();
        }

        private void Data_Filter(object sender, FilterEventArgs e)
        {
            var tmp = e.Item as FileShowInfo;
            switch (Samefilter)
            {
                case 0:
                    if (string.IsNullOrEmpty(txtSearch.Text))
                        e.Accepted = true;
                    else if (tmp.FilePath.Contains(txtSearch.Text) || tmp.FileName.Contains(txtSearch.Text))
                        e.Accepted = true;
                    else
                        e.Accepted = false;
                    break;
                case 1://相同的留下
                    e.Accepted = !tmp.NotSame;
                    break;
                case -1:
                    e.Accepted = tmp.NotSame;
                    break;
            }
        }
        #endregion

        #region 右键菜单操作
        private void MOption_Click(object sender, RoutedEventArgs e)
        {
            string Type = (sender as MenuItem).Header.ToString();//操作类型
            List<FileShowInfo> tmp = new List<FileShowInfo>();
            switch (Type)
            {
                case "删除":
                    foreach (FileShowInfo obj in dataGrid.SelectedItems)
                    {
                        File.Delete(obj.FullName);
                        tmp.Add(obj);
                    }
                    break;
                case "剪切":
                    foreach (FileShowInfo obj in dataGrid.SelectedItems)
                    {
                        string target = obj.FullName.Replace(viewModel.DirectoryPath, otherVM.DirectoryPath);
                        if (!Directory.Exists(Path.GetDirectoryName(target)))
                            Directory.CreateDirectory(Path.GetDirectoryName(target));
                        File.Move(obj.FullName, target);
                        tmp.Add(obj);
                    }
                    otherVM.BuildFiles();
                    break;
                case "复制":
                    foreach (FileShowInfo obj in dataGrid.SelectedItems)
                    {
                        string target = obj.FullName.Replace(viewModel.DirectoryPath, otherVM.DirectoryPath);
                        if (!Directory.Exists(Path.GetDirectoryName(target)))
                            Directory.CreateDirectory(Path.GetDirectoryName(target));
                        File.Move(obj.FullName, target);
                    }
                    otherVM.BuildFiles();
                    break;
            }
            tmp.ForEach(x => viewModel.ShowFiles.Remove(x));
        }

        private void MCompare_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedItems.Clear();
            viewModel.Compared = true;
            bool contains;
            foreach (FileShowInfo self in viewModel.ShowFiles)
            {
                contains = false;
                foreach (FileShowInfo other in otherVM.ShowFiles)
                {
                    if (self.FileName == other.FileName && self.FileType == other.FileType)
                    {
                        contains = true;//对侧包含该文件
                        break;
                    }
                }
                if (!contains)
                {
                    self.NotSame = true;
                    dataGrid.SelectedItems.Add(self);
                }
                else
                {
                    self.NotSame = false;
                }
            }
        }

        private void MDirOption_Click(object sender, RoutedEventArgs e)
        {
            string dir = (sender as MenuItem).Tag.ToString();//文件夹相对路径
            string Type = (sender as MenuItem).Header.ToString();//操作类型
            switch (Type)
            {
                case "删除文件夹": Function.DeleteDir(Path.Combine(viewModel.DirectoryPath, dir)); break;
                case "剪切文件夹":
                    if (otherVM.DirectoryPath.Length > 0)
                    {
                        Function.CutDir(Path.Combine(viewModel.DirectoryPath, dir), viewModel.DirectoryPath, otherVM.DirectoryPath);
                        otherVM.BuildFiles();
                    }
                    break;
                case "复制文件夹":
                    if (otherVM.DirectoryPath.Length > 0)
                    {
                        Function.CopyDir(Path.Combine(viewModel.DirectoryPath, dir), viewModel.DirectoryPath, otherVM.DirectoryPath);
                        otherVM.BuildFiles();
                    }
                    break;
            }
            try
            {
                if (Type != "复制文件夹")
                {
                    for (int i = viewModel.ShowFiles.Count - 1; i >= 0; i--)
                    {
                        if (viewModel.ShowFiles[i].FilePath == dir)
                            viewModel.ShowFiles.RemoveAt(i);
                    }
                }
            }
            catch { }
        }
        #endregion

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var sortKey = (sender as RadioButton).Tag.ToString();
            if (currentSort == sortKey) return;//没有变化直接退出
            currentSort = sortKey;
            cvsList?.GroupDescriptions.Clear();
            if (currentSort != "None")
                cvsList?.GroupDescriptions.Add(new PropertyGroupDescription(currentSort));
        }

        private void BtReplace_Click(object sender, RoutedEventArgs e) => viewModel.Replace();
    }
}
