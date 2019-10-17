using MulTools.Components;
using MulTools.Components.Class;
using MulTools.Properties;
using System;
using System.Collections.Generic;
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
            AnimatedGif.AnimatedGifCreator gif = AnimatedGif.AnimatedGif.Create(fileName, Settings.Default.Gif帧间隔);
            DirectoryInfo dirInfo = new DirectoryInfo(CombineTempPath);
            foreach (FileSystemInfo imgFile in dirInfo.GetFileSystemInfos())
            {
                Image img = Image.FromFile(imgFile.FullName);
                gif.AddFrame(img);
                img.Dispose();
            }
            gif.Dispose();
            if (Settings.Default.Is删除GIF临时文件)
                Functions.DeleteDir(CombineTempPath);
            if (Settings.Default.Pic截图同步到剪切板)
                Clipboard.SetImage(new Bitmap(fileName));
        }

        private void PicToLong()
        {
            Settings Ss = Settings.Default;
            string fileName = string.Format("{0}/L{1}.", txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss")) + Ss.截图文件类型;
            string combineArgs = string.Format("{0} {1} {2} {3}", Ss.Long相似度.ToString(), Ss.Long下限值.ToString(), Ss.Long上限值.ToString(), Ss.Long合成方向);
            string argsTemplate = Ss.Long实时合成 ? "PicCombine {0} {1} {2} {3}" : "DirCombine {0} {1} {2} {3}";
            string strResult;
            if (Ss.Long实时合成)
            {
                fileList = new List<string>();
                while (btLong.Text == "停止" || fileQueue.Count > 0)//不停止或者队列没空不出循环
                {
                    InLongWork = true;
                    if (fileQueue.Count > 0)
                    {
                        if (fileList.Count < 2)//不足两个则补足两个
                            fileList.Add(fileQueue.Dequeue());
                        else//到两个之后则末位替换
                            fileList[1] = fileQueue.Dequeue();
                        if (fileList.Count == 2)
                        {
                            //strResult = Functions.UsePython("PictureCombiner.py", string.Format(argsTemplate, fileList[0], fileList[1], fileName, combineArgs));
                            strResult = Functions.SubProcess("PictureCombiner", string.Format(argsTemplate, fileList[0], fileList[1], fileName, combineArgs));
                            if (!strResult.Contains("拼接完成"))
                            {
                                MessageBox.Show("图片合成出现错误，请联系作者本人\n" + strResult);
                                BtLong_Click(null, null);
                                return;
                            }
                            fileList[0] = fileName;
                        }
                    }
                }
                InLongWork = false;
            }
            else
            {
                //strResult = Functions.UsePython("CaptureLongScreen.py", string.Format(argsTemplate, CombineTempPath, fileName, Ss.截图文件类型, combineArgs));
                strResult = Functions.SubProcess("CaptureLongScreen", string.Format(argsTemplate, CombineTempPath, fileName, Ss.截图文件类型, combineArgs));
                if (!strResult.Contains("拼接完成"))
                {
                    MessageBox.Show("图片合成出现错误，请联系作者本人");
                    BtLong_Click(null, null);
                }
            }
            if (Ss.Pic截图同步到剪切板)
                Clipboard.SetImage(new Bitmap(fileName));
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
        }

        private void TimerPic_Elapsed(object sender, System.Timers.ElapsedEventArgs e) => BtJPG_Click(null, null);

        private void BtSavePath_Click(object sender, EventArgs e)
        {
            if (DirPathDg.ShowDialog() == DialogResult.OK)
                txtPath.Text = DirPathDg.SelectedPath;
        }

        private void BtCLose_Click(object sender, EventArgs e) => Close();

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && Directory.Exists(txtPath.Text))//从友好性出发，增加直接打开存图片的文件夹的方法
                System.Diagnostics.Process.Start("Explorer.exe", txtPath.Text);
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

        private void MouseHook_MouseWheel(object sender, MouseEventArgs e) => scPen.Width += e.Delta / 100;

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
                Graphics g = Graphics.FromImage(bitmap);//创建画板
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawLine(scPen, start, end);//画线
                start = end;//将结束位置再次作为开始位置
                g.Dispose();
                picBox.Image = bitmap;
            }
        }
        #endregion

        #region 画笔相关
        private void Bt_Click(object sender, EventArgs e) => scPen.Color = ((Button)sender).BackColor;

        private void BtPen_Click(object sender, EventArgs e)
        {
            if (btPen.Text == "启动画笔")
            {
                inDraw = true;
                btPen.Text = "关闭画笔";
                mouseHook.Start();
                PrepareToDraw(true);
            }
            else
            {
                inDraw = false;
                btPen.Text = "启动画笔";
                mouseHook.Stop();
                PrepareToDraw(false);
            }
        }

        private void PrepareToDraw(bool begin)
        {
            if (Settings.Default.h画笔穿透)
            {
                bitmap = new Bitmap(picBox.Width, picBox.Height);
                picBox.Image = bitmap;
            }
            else if(begin)
            {
                bitmap = GetWindow(true);
                picBox.Image = bitmap;
                TransparencyKey = Color.Peru;
            }
            else
            {
                bitmap = new Bitmap(picBox.Width, picBox.Height);
                picBox.Image = bitmap;
                TransparencyKey = Color.Transparent;
            }
        }
        #endregion

        #region 截图按钮
        private Bitmap GetWindow(bool containBorder = false)
        {
            int w, h;
            if (containBorder)
            {
                w = Functions.GetRated(picBox.Width);
                h = Functions.GetRated(picBox.Height);
            }
            else
            {
                w = Functions.GetRated(picBox.Width) - Convert.ToInt16(Math.Ceiling(2 * Functions.Rate)) - 1;
                h = Functions.GetRated(picBox.Height) - Convert.ToInt16(Math.Ceiling(2 * Functions.Rate)) - 1;
            }
            Bitmap bt = new Bitmap(w, h);
            using (Graphics gp = Graphics.FromImage(bt))
            {
                int W = Functions.GetRated(Location.X + picBox.Location.X);
                int H = Functions.GetRated(Location.Y + picBox.Location.Y);
                if (containBorder)
                {
                    gp.CopyFromScreen(W, H, 0, 0, new Size(w, h));
                }
                else
                {
                    gp.CopyFromScreen(W + Convert.ToInt16(Math.Ceiling(1 * Functions.Rate)),
                        H + Convert.ToInt16(Math.Ceiling(1 * Functions.Rate)), 0, 0, new Size(w, h));
                }
            }
            return bt;
        }

        private void BtJPG_Click(object sender, EventArgs e)
        {
            Bitmap bt = GetWindow();
            bt.Save(string.Format("{0}/{1}.", timerPic.Enabled ? CombineTempPath : txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss")) + Settings.Default.截图文件类型);
            if (Settings.Default.Pic截图同步到剪切板)
                Clipboard.SetImage(bt);
            bt.Dispose();
        }

        private void BtGif_Click(object sender, EventArgs e)
        {
            if (btGif.Text == "动图")
            {
                btGif.BackColor = Color.RoyalBlue;
                btGif.Text = "停止";
                CombineTempPath = Path.Combine(txtPath.Text, DateTime.Now.ToString("yyMMdd_HHmmss"));
                Directory.CreateDirectory(CombineTempPath);
                timerPic.Interval = Settings.Default.Gif截图间隔;
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
                CombineTempPath = Path.Combine(txtPath.Text, DateTime.Now.ToString("MMddHHmmss"));
                Directory.CreateDirectory(CombineTempPath);
                timerPic.Interval = Settings.Default.Long截图间隔;
                if (Settings.Default.Long实时合成)
                {
                    FileSystemWatcher LongfileWatcher = new FileSystemWatcher();
                    LongfileWatcher.Path = CombineTempPath;
                    LongfileWatcher.EnableRaisingEvents = true;
                    LongfileWatcher.SynchronizingObject = this;
                    LongfileWatcher.Created += new FileSystemEventHandler(LongfileWatcher_Created);
                    fileQueue = new Queue<string>();
                    bgWorkerLong.RunWorkerAsync();
                }
                timerPic.Start();
            }
            else
            {
                timerPic.Stop();
                btLong.BackColor = Color.Aquamarine;
                ChangeBtLongText("长图");//有的时候来自Bgworker的异常，从其他线程提前终止
                if (!Settings.Default.Long实时合成)
                {
                    lbBar.Visible = true;
                    bgWorkerLong.RunWorkerAsync();
                }
                else if(InLongWork)//实时合成但是没合成完也要阻挡其他操作
                    lbBar.Visible = true;
            }
        }

        private delegate void DGChangeBtLongText(string txt);
        private void ChangeBtLongText(string txt)
        {
            if (btLong.InvokeRequired)
                Invoke(new DGChangeBtLongText(ChangeBtLongText), new object[] { txt });
            else
                btLong.Text = txt;
        }
        #endregion

        #region BackGroundWorker
        private void BgWorkerLong_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            PicToLong();
            if (Settings.Default.Is删除长图临时文件)
                Functions.DeleteDir(CombineTempPath);
        }

        private void BgWorkerLong_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) => lbBar.Visible = false;
        #endregion

        #region 参数设置
        private void SettingMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            Settings.Default.Gif帧间隔 = Convert.ToInt32(menu_GIFframetime.Text);
            Settings.Default.Gif截图间隔 = Convert.ToInt32(menu_txtGiftime.Text);
            Settings.Default.Long截图间隔 = Convert.ToInt32(menu_txtLongtime.Text);
            Settings.Default.Is删除GIF临时文件 = menu_cmbGIF.Text.Equals("是");
            Settings.Default.Is删除长图临时文件 = menu_cmbLong.Text.Equals("是");
            Settings.Default.截图文件类型 = menu_cmbPicType.Text;
            Settings.Default.默认保存路径 = menu_cmbPath.Text == "是" ? txtPath.Text : "";
            Settings.Default.Long相似度 = Convert.ToDouble(txtSimilar.Text);
            Settings.Default.Long下限值 = Convert.ToInt32(txtLow.Text);
            Settings.Default.Long上限值 = Convert.ToInt32(txtHeigh.Text);
            Settings.Default.Long合成方向 = menu_cmbLongType.Text.Equals("垂直") ? "V" : "H";
            Settings.Default.Long实时合成 = menu_cmbRealTime.Text.Equals("是");
            Settings.Default.Pic截图同步到剪切板 = menu_cmbClipboard.Text.Equals("是");
            Settings.Default.h画笔穿透 = menu_cmbThrough.Text.Equals("是");
        }

        private void SettingMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menu_GIFframetime.Text = Settings.Default.Gif帧间隔.ToString();
            menu_txtGiftime.Text = Settings.Default.Gif截图间隔.ToString();
            menu_txtLongtime.Text = Settings.Default.Long截图间隔.ToString();
            menu_cmbGIF.Text = Settings.Default.Is删除GIF临时文件 ? "是" : "否";
            menu_cmbLong.Text = Settings.Default.Is删除长图临时文件 ? "是" : "否";
            menu_cmbPicType.Text = Settings.Default.截图文件类型;
            menu_cmbPath.Text = string.IsNullOrEmpty(Settings.Default.默认保存路径) ? "否" : "是";
            menu_cmbLongType.Text = Settings.Default.Long合成方向 == "V" ? "垂直" : "水平";
            txtSimilar.Text = Settings.Default.Long相似度.ToString();
            txtLow.Text = Settings.Default.Long下限值.ToString();
            txtHeigh.Text = Settings.Default.Long上限值.ToString();
            menu_cmbRealTime.Text = Settings.Default.Long实时合成 ? "是" : "否";
            menu_cmbClipboard.Text = Settings.Default.Pic截图同步到剪切板 ? "是" : "否";
            menu_cmbThrough.Text = Settings.Default.h画笔穿透 ? "是" : "否";
        }
        #endregion

        #region 实时合成长图
        private Queue<string> fileQueue;
        private List<string> fileList;
        private bool InLongWork = false;
        private void LongfileWatcher_Created(object sender, FileSystemEventArgs e) => fileQueue.Enqueue(e.FullPath);
        #endregion
    }
}
 