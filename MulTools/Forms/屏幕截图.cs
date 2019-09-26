using MulTools.Function;
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
        private Point start = new Point();// 屏笔起始点
        private Point end = new Point();// 屏笔结束点
        private readonly MouseHook mouseHook = new MouseHook();// 鼠标钩子
        private readonly KeyboardHook keyboardHook = new KeyboardHook();// 键盘钩子
        private System.Timers.Timer timerPic = null;
        private string CombineTempPath;
        #endregion

        private Point GetPoint(Point point)
        {
            Point a = Functions.GetRated(point);
            Point r = new Point(a.X - Location.X - picBox.Location.X - 6, a.Y - Location.Y - picBox.Location.Y - 30);
            return r;
        }

        private void PicToGif()
        {
            string fileName = string.Format("{0}/{1}.gif", txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss"));
            //Delay time is one hundredths (1/100) of a second between frames;
            AnimatedGif.AnimatedGifCreator gif = AnimatedGif.AnimatedGif.Create(fileName, 100);//这里因为timer设置的100ms这里对应就写的10
            DirectoryInfo dirInfo = new DirectoryInfo(CombineTempPath);
            foreach (FileSystemInfo imgFile in dirInfo.GetFileSystemInfos())
            {
                Image img = Image.FromFile(imgFile.FullName);
                gif.AddFrame(img);
                img.Dispose();
            }
            gif.Dispose();
            Functions.DeleteDir(CombineTempPath);
        }

        private void PicToLong()
        {
            string fileName = string.Format("{0}/L{1}.bmp", txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss"));
            Functions.PyFunc(string.Format("{0} {1}", CombineTempPath, fileName));//因为用了numpy打包的话exe有240多MB，这里就直接用py了
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
            timerPic = new System.Timers.Timer(100);
            timerPic.Elapsed += TimerPic_Elapsed;
        }

        private void TimerPic_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BtJPG_Click(null, null);
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
        #endregion

        #region 画笔相关
        /// <summary>
        /// 点击颜色按钮事件
        /// </summary>
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
            Graphics gp = Graphics.FromImage(bt);
            gp.CopyFromScreen(Functions.GetRated(Location.X + picBox.Location.X) + Convert.ToInt16(Math.Ceiling(1 * Functions.Rate)),
                Functions.GetRated(Location.Y + picBox.Location.Y) + Convert.ToInt16(Math.Ceiling(1 * Functions.Rate)), 0, 0, new Size(w, h));
            string fileName = timerPic.Enabled ? CombineTempPath : txtPath.Text;
            fileName = string.Format("{0}/{1}.bmp", fileName, DateTime.Now.ToString("yyMMdd_HHmmss"));
            bt.Save(fileName);
            bt.Dispose();
            gp.Dispose();
        }

        private void BtGif_Click(object sender, EventArgs e)
        {
            if (btGif.Text == "动图")
            {
                btGif.BackColor = Color.RoyalBlue;
                btGif.Text = "停止";
                CombineTempPath = Path.Combine(txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss"));
                Directory.CreateDirectory(CombineTempPath);
                timerPic.Interval = 100;
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
                CombineTempPath = Path.Combine(txtPath.Text, "长图");
                Directory.CreateDirectory(CombineTempPath);
                timerPic.Interval = 300;
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
            Functions.DeleteDir(CombineTempPath);
        }

        private void bgWorkerLong_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lbBar.Visible = false;
        }
        #endregion

        #region 无边框窗体移动
        private bool InClick = false;
        private Point mouseOff;//鼠标移动位置变量

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                InClick = true; //点击左键按下时标注为true
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            if (InClick)
                InClick = false;//释放鼠标后标注为false
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (InClick)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        #endregion

        #region 调整窗体大小
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息 
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标 
                    m.LParam = IntPtr.Zero;//默认值 
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        private void BtSavePath_Click(object sender, EventArgs e)
        {
            if (DirPathDg.ShowDialog() == DialogResult.OK)
                txtPath.Text = DirPathDg.SelectedPath;
        }

        private void btCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
 