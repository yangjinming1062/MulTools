using MulTools.Components;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MulTools.Forms
{
    public partial class 文件操作 : Form
    {
        public 文件操作()
        {
            InitializeComponent();
        }

        private void CompareFile(uc文件操作 A, uc文件操作 B)
        {
            bool contains;
            foreach (ListViewItem a in A.fileLV.Items)
            {
                contains = false;
                foreach (ListViewItem b in B.fileLV.Items)
                {
                    if (rbFileName.Checked)
                    {
                        if (Path.GetFileName(a.Name) == Path.GetFileName(b.Name))
                        {
                            contains = true;
                            break;
                        }
                    }
                    else if (rbMD5.Checked)
                    {
                        if (a.SubItems[(int)Cols.文件类型].Text != "文件夹")
                        {
                            if (a.SubItems[(int)Cols.MD5].Text == b.SubItems[(int)Cols.MD5].Text)
                            {
                                contains = true;
                                break;
                            }
                        }
                        else
                        {
                            if (a.SubItems[(int)Cols.文件名].Text == b.SubItems[(int)Cols.文件名].Text && b.SubItems[(int)Cols.文件类型].Text == "文件夹")//文件夹无md5
                            {
                                contains = true;
                                break;
                            }
                        }
                    }
                }
                if (!contains)
                    a.BackColor = Color.Lime;
                else
                    a.BackColor = Color.White;
            }
        }

        private void 文件操作_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
            uc文件操作L.CurrentDirEvent += Uc文件操作L_CurrentDirEvent;
            uc文件操作R.CurrentDirEvent += Uc文件操作R_CurrentDirEvent;
        }

        private void Uc文件操作R_CurrentDirEvent(string dirPath)
        {
            uc文件操作L.TargetDirPath = dirPath;
        }

        private void Uc文件操作L_CurrentDirEvent(string dirPath)
        {
            uc文件操作R.TargetDirPath = dirPath;
        }

        private void RbMD5_CheckedChanged(object sender, EventArgs e)
        {
            uc文件操作L.NeedMD5 = rbMD5.Checked;
            uc文件操作R.NeedMD5 = rbMD5.Checked;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtLeft_Click(object sender, EventArgs e)
        {
            CompareFile(uc文件操作L, uc文件操作R);
        }

        private void BtRight_Click(object sender, EventArgs e)
        {
            CompareFile(uc文件操作R, uc文件操作L);
        }

        #region 无边框窗体移动
        private bool InClick = false;
        private Point mouseOff;//鼠标移动位置变量

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                InClick = true; //点击左键按下时标注为true
            }
        }

        private void PanelTop_MouseUp(object sender, MouseEventArgs e)
        {
            if (InClick)
                InClick = false;//释放鼠标后标注为false
        }

        private void PanelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (InClick)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        #endregion
    }
}
