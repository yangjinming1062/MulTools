using MulTools.Components;
using MulTools.Components.Class;
using MulTools.Properties;
using System;
using System.Drawing;
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
        private Point start;// 屏笔起始点
        private Point end;// 屏笔结束点
        private readonly MouseHook mouseHook = new MouseHook();// 鼠标钩子
        private readonly KeyboardHook keyboardHook = new KeyboardHook();// 键盘钩子
        private System.Timers.Timer timerPic;
        private string CombineTempPath;
        #endregion

        private Point GetPoint(Point point)
        {
            Point a = Functions.GetRated(point);
            return new Point(a.X - Location.X - picBox.Location.X, a.Y - Location.Y - picBox.Location.Y);
        }

        private void PicToGif()
        {
            string fileName = string.Format("{0}/{1}.gif", txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss"));
            //Delay time is one hundredths (1/100) of a second between frames;
            AnimatedGif.AnimatedGifCreator gif = AnimatedGif.AnimatedGif.Create(fileName, Settings.Default.GifFrameTime);//这里因为timer设置的100ms这里对应就写的10
            DirectoryInfo dirInfo = new DirectoryInfo(CombineTempPath);
            foreach (FileSystemInfo imgFile in dirInfo.GetFileSystemInfos())
            {
                Image img = Image.FromFile(imgFile.FullName);
                gif.AddFrame(img);
                img.Dispose();
            }
            gif.Dispose();
            if (Settings.Default.DelGitTempPic)
                Functions.DeleteDir(CombineTempPath);
        }

        private void PicToLong()
        {
            string fileName = string.Format("{0}/L{1}", txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss"));
            //6个参数，分别是待处理文件夹，长图名称，待处理文件类型，相似度参数，最小值上限，最大值下限；后四个有默认值可以不修改
            string res = Functions.BuildLongPic(string.Format("{0} {1}.{2} {3} {4} {5} {6}", CombineTempPath, fileName, Settings.Default.PicType,
                Settings.Default.PicType, Settings.Default.LongPicSimilar.ToString(), Settings.Default.LongPicLow.ToString(), Settings.Default.LongPicHeigh.ToString()));
            if (res.Equals("拼接完成"))
            {
                MessageBox.Show("图片合成出现错误，请联系作者本人");
                BtLong_Click(null, null);
            }
        }

        private void 屏幕截图_Load(object sender, EventArgs e)
        {
            scPen = new Pen(new SolidBrush(Color.Red), 3);
            mouseHook.MouseMove += MouseHook_MouseMove;
            mouseHook.MouseDown += MouseHook_MouseDown;
            mouseHook.MouseUp += MouseHook_MouseUp;
            mouseHook.MouseWheel += MouseHook_MouseWheel;
            keyboardHook.KeyDown += KeyboardHook_KeyDown;
            keyboardHook.Start();

            txtPath.Text = Path.Combine(Application.StartupPath, "屏幕截图");
            if (!Directory.Exists(txtPath.Text))
                Directory.CreateDirectory(txtPath.Text);
            timerPic = new System.Timers.Timer();
            timerPic.Elapsed += TimerPic_Elapsed;
            NoneBorderHelper.Set(this, panelTop);

            menu_GIFframetime.Text = Settings.Default.GifFrameTime.ToString();
            menu_txtGiftime.Text = Settings.Default.GifInterval.ToString();
            menu_txtLongtime.Text = Settings.Default.LongInterval.ToString();
            menu_cmbGIF.Text = Settings.Default.DelGitTempPic ? "是" : "否";
            menu_cmbLong.Text = Settings.Default.DelLongTempPic ? "是" : "否";
            menu_cmbPicType.Text = Settings.Default.PicType;
            menu_cmbPath.Text = string.IsNullOrEmpty(Settings.Default.SavePath) ? "否" : "是";
            txtSimilar.Text = Settings.Default.LongPicSimilar.ToString();
            txtLow.Text = Settings.Default.LongPicLow.ToString();
            txtHeigh.Text = Settings.Default.LongPicHeigh.ToString();
        }

        private void 屏幕截图_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.GifFrameTime = Convert.ToInt32(menu_GIFframetime.Text);
            Settings.Default.GifInterval = Convert.ToInt32(menu_txtGiftime.Text);
            Settings.Default.LongInterval = Convert.ToInt32(menu_txtLongtime.Text);
            Settings.Default.DelGitTempPic = menu_cmbGIF.Text.Equals("是");
            Settings.Default.DelLongTempPic = menu_cmbLong.Text.Equals("是");
            Settings.Default.PicType = menu_cmbPicType.Text;
            Settings.Default.SavePath = menu_cmbPath.Text == "是" ? txtPath.Text : "";
            Settings.Default.LongPicSimilar = Convert.ToDouble(txtSimilar.Text);
            Settings.Default.LongPicLow = Convert.ToInt32(txtLow.Text);
            Settings.Default.LongPicHeigh = Convert.ToInt32(txtHeigh.Text);
        }

        private void TimerPic_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BtJPG_Click(null, null);
        }

        private void BtSavePath_Click(object sender, EventArgs e)
        {
            if (DirPathDg.ShowDialog() == DialogResult.OK)
                txtPath.Text = DirPathDg.SelectedPath;
        }

        private void btCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 监视鼠标键盘
        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                Location = new Point(Location.X, Location.Y - 1);
            else if (e.KeyCode == Keys.Down)
                Location = new Point(Location.X, Location.Y + 1);
            else if (e.KeyCode == Keys.Left)
                Location = new Point(Location.X - 1, Location.Y);
            else if (e.KeyCode == Keys.Right)
                Location = new Point(Location.X + 1, Location.Y);

            if (e.KeyCode == Keys.Escape)
            {
                if (inDraw)
                {
                    bitmap = new Bitmap(picBox.Width, picBox.Height);
                    picBox.Image = bitmap;
                }
                if (btLong.Text == "停止")
                    BtLong_Click(null, null);
                if (btGif.Text == "停止")
                    BtGif_Click(null, null);
            }
        }

        private void MouseHook_MouseWheel(object sender, MouseEventArgs e)
        {
            scPen.Width += e.Delta / 100;
        }

        private void MouseHook_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseClick && e.Button == MouseButtons.Left)
                mouseClick = false;
        }

        private void MouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            //因为不影响屏幕的操作，有的时候左键按下会有其他效果，增加右键
            if (inDraw && (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
            {
                start = GetPoint(e.Location);//记录开始位置
                mouseClick = true;//鼠标左键点下 则开始绘制
            }
        }

        private void MouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (inDraw && mouseClick)
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
        #endregion

        #region 画笔相关
        private void Bt_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            scPen.Color = bt.BackColor;
        }

        private void BtPen_Click(object sender, EventArgs e)
        {
            if (btPen.Text == "启动画笔")
            {
                inDraw = true;
                btPen.Text = "关闭画笔";
                mouseHook.Start();
            }
            else
            {
                inDraw = false;
                btPen.Text = "启动画笔";
                mouseHook.Stop();
            }
            bitmap = new Bitmap(picBox.Width, picBox.Height);
            picBox.Image = bitmap;
        }
        #endregion

        #region 截图按钮
        private void BtJPG_Click(object sender, EventArgs e)
        {
            int w = Functions.GetRated(picBox.Width) - Convert.ToInt16(Math.Ceiling(2 * Functions.Rate)) - 1;
            int h = Functions.GetRated(picBox.Height) - Convert.ToInt16(Math.Ceiling(2 * Functions.Rate)) - 1;
            Bitmap bt = new Bitmap(w, h);
            using (Graphics gp = Graphics.FromImage(bt))
            {
                gp.CopyFromScreen(Functions.GetRated(Location.X + picBox.Location.X) + Convert.ToInt16(Math.Ceiling(1 * Functions.Rate)),
                    Functions.GetRated(Location.Y + picBox.Location.Y) + Convert.ToInt16(Math.Ceiling(1 * Functions.Rate)), 0, 0, new Size(w, h));
                bt.Save(string.Format("{0}/{1}.", timerPic.Enabled ? CombineTempPath : txtPath.Text, 
                    DateTime.Now.ToString("yyMMdd_HHmmss")) + Settings.Default.PicType);
                bt.Dispose();
            }
        }

        private void BtGif_Click(object sender, EventArgs e)
        {
            if (btGif.Text == "动图")
            {
                btGif.BackColor = Color.RoyalBlue;
                btGif.Text = "停止";
                CombineTempPath = Path.Combine(txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss"));
                Directory.CreateDirectory(CombineTempPath);
                timerPic.Interval = Settings.Default.GifInterval;
                timerPic.Start();
            }
            else
            {
                timerPic.Stop();
                btGif.BackColor = Color.Aquamarine;
                btGif.Text = "动图";
                PicToGif();
            }
        }

        private void BtLong_Click(object sender, EventArgs e)
        {
            if (btLong.Text == "长图")
            {
                btLong.BackColor = Color.RoyalBlue;
                btLong.Text = "停止";
                CombineTempPath = Path.Combine(txtPath.Text, DateTime.Now.ToString("MMddHHmm"));
                Directory.CreateDirectory(CombineTempPath);
                timerPic.Interval = Settings.Default.LongInterval;
                timerPic.Start();
            }
            else
            {
                timerPic.Stop();
                btLong.BackColor = Color.Aquamarine;
                btLong.Text = "长图";
                lbBar.Visible = true;
                bgWorkerLong.RunWorkerAsync();
            }
        }
        #endregion

        #region BackGroundWorker事件
        private void bgWorkerLong_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            PicToLong();
            if (Settings.Default.DelLongTempPic)
                Functions.DeleteDir(CombineTempPath);
        }

        private void bgWorkerLong_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lbBar.Visible = false;
        }
        #endregion
    }
}
 