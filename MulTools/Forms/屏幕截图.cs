﻿using MulTools.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MulTools.Forms
{
    public partial class 屏幕截图 : Form
    {
        public 屏幕截图()
        {
            InitializeComponent();
        }

        #region 变量
        private Pen scPen;
        private bool inDraw = false;
        private bool mouseClick = false;
        private Bitmap bitmap;
        private Point start = new Point();// 屏笔起始点
        private Point end = new Point();// 屏笔结束点
        private MouseHook mouseHook = new MouseHook();// 鼠标钩子
        private KeyboardHook keyboardHook = new KeyboardHook();// 键盘钩子
        private System.Timers.Timer timerPic = null;
        private string gifTempPath;
        #endregion

        /// <summary>
        /// todo:鼠标偏移暂时还有问题，留后调整
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private Point GetPoint(Point point)
        {
            Point a = Functions.GetRated(point);
            Point b = Functions.GetRated(Location);
            Point c = Functions.GetRated(picBox.Location);
            Point r = Functions.GetRated(new Point(a.X - b.X - c.X, a.Y - b.Y - c.Y));
            r.Y -= 40;
            return r;
        }

        private void bmpTogif()
        {
            //todo
        }

        private void 屏幕截图_Load(object sender, EventArgs e)
        {
            scPen = new Pen(new SolidBrush(Color.Red), 3);
            mouseHook.MouseMove += MouseHook_MouseMove;
            mouseHook.MouseDown += MouseHook_MouseDown;
            mouseHook.MouseUp += MouseHook_MouseUp;
            mouseHook.MouseWheel += MouseHook_MouseWheel;
            keyboardHook.KeyDown += KeyboardHook_KeyDown;

            txtPath.Text = Path.Combine(Application.StartupPath, "屏幕截图");
            gifTempPath = Path.Combine(txtPath.Text, "temp");
            if (!Directory.Exists(txtPath.Text))
                Directory.CreateDirectory(txtPath.Text);
            if (!Directory.Exists(gifTempPath))
                Directory.CreateDirectory(gifTempPath);
            timerPic = new System.Timers.Timer(100);
            timerPic.Elapsed += TimerPic_Elapsed;
        }

        private void TimerPic_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BtJPG_Click(null, null);
        }

        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                if(inDraw)
                {
                    bitmap = new Bitmap(picBox.Width, picBox.Height);
                    picBox.Image = bitmap;
                }
            }
        }

        private void MouseHook_MouseWheel(object sender, MouseEventArgs e)
        {
            scPen.Width += e.Delta / 100;
        }

        private void MouseHook_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseClick)
            {
                if (e.Button == MouseButtons.Left)
                    mouseClick = false;
            }
        }

        private void MouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (inDraw)//ALT+Q
            {
                //因为不影响屏幕的操作，有的时候左键按下会有其他效果，增加右键
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                {
                    start = GetPoint(e.Location);//记录开始位置
                    //鼠标左键点下 则开始绘制
                    mouseClick = true;
                }
            }
        }

        private void MouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (inDraw)
            {
                if (mouseClick)
                {
                    end = GetPoint(e.Location);//记录结束位置
                    Graphics g = System.Drawing.Graphics.FromImage(bitmap);//创建画板
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(scPen, start, end);//画线
                    start = end;//将结束位置再次作为开始位置
                    g.Dispose();
                    picBox.Image = bitmap;
                }
            }
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            scPen.Color = bt.BackColor;
        }

        private void BtJPG_Click(object sender, EventArgs e)
        {
            int w = Functions.GetRated(picBox.Width);
            int h = Functions.GetRated(picBox.Height);
            bitmap = new Bitmap(w, h);
            Graphics gp = Graphics.FromImage(bitmap);
            gp.CopyFromScreen(Functions.GetRated(Location.X) + 10, Functions.GetRated(Location.Y + picBox.Location.Y + 30), 0, 0, new Size(w, h));
            string fileName;
            if (timerPic.Enabled)
                fileName = string.Format("{0}/{1}.bmp", gifTempPath, DateTime.Now.ToString("yyMMdd_HHmmss"));
            else
                fileName = string.Format("{0}/{1}.bmp", txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss"));
            bitmap.Save(fileName);
            gp.Dispose();
        }

        private void BtGif_Click(object sender, EventArgs e)
        {
            if(btGif.Text == "动图")
            {
                btGif.BackColor = Color.RoyalBlue;
                btGif.Text = "停止";
                timerPic.Start();
            }
            else
            {
                timerPic.Stop();
                btGif.BackColor = Color.Aquamarine;
                btGif.Text = "动图";
                bmpTogif();
            }
        }

        private void BtPen_Click(object sender, EventArgs e)
        {
            if(btPen.Text == "启动画笔")
            {
                inDraw = true;
                btPen.Text = "关闭画笔";
                mouseHook.Start();
                keyboardHook.Start();
            }
            else
            {
                inDraw = false;
                btPen.Text = "启动画笔";
                mouseHook.Stop();
                keyboardHook.Stop();
            }
            bitmap = new Bitmap(picBox.Width, picBox.Height);
            picBox.Image = bitmap;
        }

        private void BtSavePath_Click(object sender, EventArgs e)
        {
            if (DirPathDg.ShowDialog() == DialogResult.OK)
                txtPath.Text = DirPathDg.SelectedPath;
        }
    }
}
