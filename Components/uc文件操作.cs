using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MulTools.Components
{
    public partial class uc文件操作 : UserControl
    {
        public uc文件操作()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 是否生成文件的MD5
        /// </summary>
        public bool NeedMD5 = false;

        private string _targetDIrPath = string.Empty;
        /// <summary>
        /// 移动文件的目标文件夹属性
        /// </summary>
        public string TargetDirPath
        {
            get => _targetDIrPath;
            set
            {
                tsmItemCopy.Visible = !string.IsNullOrEmpty(value);
                tsmItemCut.Visible = !string.IsNullOrEmpty(value);
                _targetDIrPath = value;
            }
        }

        public List<ListViewItem> lsFile = new List<ListViewItem>();
        /// <summary>
        /// 生成文件列表
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="hsType"></param>
        /// <returns></returns>
        private bool BuildList(string filePath, ref Hashtable hsType)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            try//因为子文件夹的普通文件的命名也不能直接显示名，所以不能在for循环中判断是否递归模式，递归模式切换在for外面
            {
                string[] lsItem = new string[3];
                foreach (FileSystemInfo file in dirInfo.GetFileSystemInfos())
                {
                    if (file.Attributes == FileAttributes.Directory || string.IsNullOrEmpty(file.Extension))
                    {
                        if (cbDG.Checked)
                            BuildList(file.FullName, ref hsType);
                        else
                        {
                            lsItem[(int)Cols.文件名] = file.Name;
                            lsItem[(int)Cols.文件类型] = "文件夹";
                        }
                    }
                    else
                    {
                        lsItem[(int)Cols.文件名] = Path.GetFileNameWithoutExtension(file.FullName);
                        lsItem[(int)Cols.文件类型] = file.Extension;
                    }

                    if (string.IsNullOrEmpty(lsItem[(int)Cols.文件类型]))//目录递归下去不处理就是一行空白，要么显示空目录，要么不显示
                        continue;//跳过不显示

                    if (!hsType.ContainsKey(lsItem[(int)Cols.文件类型]))
                        hsType.Add(lsItem[(int)Cols.文件类型], null);
                    if (NeedMD5 && !string.IsNullOrEmpty(lsItem[(int)Cols.文件类型]) && lsItem[(int)Cols.文件类型] != "文件夹" && string.IsNullOrEmpty(lsItem[(int)Cols.MD5]))
                    {
                        //lsItem[(int)Cols.MD5] = BulidMD5(file.FullName);
                        //主要目的是记录带参数的多线程的调用
                        System.Threading.Thread th = new System.Threading.Thread(() => BulidMD5(file.FullName, ref lsItem[(int)Cols.MD5]));
                        th.Start();
                    }

                    ListViewItem item = new ListViewItem(lsItem)
                    {
                        Name = file.FullName
                    };
                    lsItem = new string[3];
                    lsFile.Add(item);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private string BulidMD5(string filePath, ref string res)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            FileStream fs = new FileStream(filePath, FileMode.Open);
            md5.Initialize();
            byte[] bytes = md5.ComputeHash(fs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            res = sb.ToString();
            return res;
        }

        #region 按钮事件
        private void BtBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                txtDirpath.Text = folderBrowser.SelectedPath;
        }

        private void BtBack_Click(object sender, EventArgs e)
        {
            if (txtDirpath.Text.LastIndexOf("\\") > 1)
                txtDirpath.Text = txtDirpath.Text.Substring(0, txtDirpath.Text.LastIndexOf("\\"));
        }

        private void BtOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDirpath.Text))
                System.Diagnostics.Process.Start("Explorer.exe", txtDirpath.Text);
        }

        private void BtReplace_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text))
                return;
            string NewName;
            foreach (ListViewItem file in fileLV.Items)
            {
                if (file.SubItems[(int)Cols.文件名].Text.Contains(txtSource.Text))
                {
                    NewName = Path.Combine(txtDirpath.Text, file.SubItems[(int)Cols.文件名].Text.Replace(txtSource.Text, txtTarget.Text) + file.SubItems[(int)Cols.文件类型].Text);
                    try
                    {
                        File.Move(file.Name, NewName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            TxtDirpath_TextChanged(null, null);
        }

        private void BtReName_Click(object sender, EventArgs e)
        {
            int count = 0;
            string NewName;
            int length = fileLV.Items.Count.ToString().Length;
            foreach (ListViewItem file in fileLV.Items)
            {
                NewName = Path.Combine(txtDirpath.Text, txtReName.Text + "[" + count.ToString().PadLeft(length, '0') + "]" + file.SubItems[(int)Cols.文件类型].Text);
                try
                {
                    File.Move(file.Name, NewName);
                    count += 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            TxtDirpath_TextChanged(null, null);
        }
        #endregion

        #region 多线程，委托,事件
        private delegate void DGtbPanelAdd(Control control, int c, int r);
        private void tbPanelAdd(Control control, int c, int r)
        {
            if (tbPanel.InvokeRequired)
            {
                DGtbPanelAdd dg = new DGtbPanelAdd(tbPanelAdd);
                Invoke(dg, new object[] { control, c, r });
            }
            else
            {
                tbPanel.Controls.Add(control, c, r);
            }
        }

        public delegate void CurrentDir(string dirPath);//事件需要的委托
        public event CurrentDir CurrentDirEvent;//事件发布者
        #endregion

        #region BackgroudWorker相关事件
        private void BgWorker_BuildList(object sender, DoWorkEventArgs e)
        {
            Hashtable hsType = new Hashtable();//存文件类型，然后根据文件类型在最下方显示勾选框
            lsFile.Clear();
            BuildList(txtDirpath.Text, ref hsType);

            #region tablePanel文件类型
            tbPanel.RowCount = Convert.ToInt32(Convert.ToDecimal(hsType.Count / tbPanel.ColumnCount));
            int index = 0;
            foreach (string type in hsType.Keys)
            {
                CheckBox cb = new CheckBox
                {
                    Text = type,
                    Checked = true,
                    ForeColor = Color.Red
                };
                cb.CheckedChanged += Cb_CheckedChanged;
                tbPanelAdd(cb, index % tbPanel.ColumnCount, index / tbPanel.ColumnCount);
                index += 1;
            }
            #endregion
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgBar.Visible = false;
            btBrowse.Enabled = true;
            fileLV.Items.AddRange(lsFile.ToArray());
        }
        #endregion

        #region 右键菜单
        private void TsmItemOpen_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem file in fileLV.SelectedItems)
            {
                System.Diagnostics.Process.Start("Explorer.exe", file.Name);
            }
        }

        private void TsmItemDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem obj in fileLV.SelectedItems)
            {
                if (obj.SubItems[(int)Cols.文件类型].Text == "文件夹")
                    MulTools.Function.Functions.DeleteDir(obj.Name);
                else
                    File.Delete(obj.Name);
                fileLV.Items.Remove(obj);
            }
        }

        private void TsmItemCut_Click(object sender, EventArgs e)
        {
            if (fileLV.SelectedItems == null || fileLV.SelectedItems.Count == 0)
                return;
            foreach (ListViewItem obj in fileLV.SelectedItems)
            {
                if (obj.SubItems[(int)Cols.文件类型].Text == "文件夹")
                    MulTools.Function.Functions.CutDir(obj.Name, txtDirpath.Text, TargetDirPath);
                else
                    File.Move(obj.Name, Path.Combine(TargetDirPath, Path.GetFileName(obj.Name)));
            }
            TxtDirpath_TextChanged(null, null);
        }

        private void TsmItemCopy_Click(object sender, EventArgs e)
        {
            if (fileLV.SelectedItems.Count > 0)
            {
                foreach (ListViewItem obj in fileLV.SelectedItems)
                {
                    if (obj.SubItems[(int)Cols.文件类型].Text == "文件夹")
                        MulTools.Function.Functions.CopyDir(obj.Name, txtDirpath.Text, TargetDirPath);
                    else
                        File.Copy(obj.Name, Path.Combine(TargetDirPath, Path.GetFileName(obj.Name)));
                }
                TxtDirpath_TextChanged(null, null);
            }
        }

        private void TsmItemReplace_Click(object sender, EventArgs e)
        {
            txtSource.Text = fileLV.FocusedItem.SubItems[(int)Cols.文件名].Text;
        }

        private void TsmItemRename_Click(object sender, EventArgs e)
        {
            txtReName.Text = fileLV.FocusedItem.SubItems[(int)Cols.文件名].Text;
        }
        #endregion

        /// <summary>
        /// 关键事件，主要功能入口处
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtDirpath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDirpath.Text))
            {
                pgBar.Visible = true;
                btBrowse.Enabled = false;
                fileLV.Items.Clear();
                lsFile.Clear();
                tbPanel.Controls.Clear();
                bgWorker.RunWorkerAsync();
                CurrentDirEvent?.Invoke(txtDirpath.Text);//及时向主form传递最新的文件夹路径
            }
            else
                CurrentDirEvent?.Invoke(string.Empty);//及时向主form传递最新的文件夹路径
        }
        /// <summary>
        /// 文件扩展类型变动
        /// </summary>
        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            string type = cb.Text;
            if (cb.Checked)
            {
                fileLV.Items.AddRange(lsFile.Where(x => x.SubItems[(int)Cols.文件类型].Text == type).ToArray());
            }
            else
            {
                #region 这种逐元素移除在多一些的时候没有清空添加快
                //var items = lsFile.Where(x => x.SubItems[(int)Cols.文件类型].Text == type);
                //foreach(var r in items)
                //{
                //    fileLV.Items.Remove(r);
                //}
                #endregion
                fileLV.Items.Clear();
                foreach (CheckBox c in tbPanel.Controls)
                {
                    if (c.Checked)
                        fileLV.Items.AddRange(lsFile.Where(x => x.SubItems[(int)Cols.文件类型].Text == c.Text).ToArray());
                }
            }
        }

        private void CbDG_CheckedChanged(object sender, EventArgs e)
        {
            TxtDirpath_TextChanged(null, null);
        }

        private void FileLV_DoubleClick(object sender, EventArgs e)
        {
            if (((ListView)(sender)).FocusedItem.SubItems[(int)Cols.文件类型].Text == "文件夹")
                txtDirpath.Text = ((ListView)(sender)).FocusedItem.Name;
        }
    }
    public enum Cols
    {
        文件名,
        文件类型,
        MD5
    }
}
