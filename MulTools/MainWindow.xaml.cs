using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Windows.Media.Animation;

namespace MulTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.Screen Screen;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Screen = System.Windows.Forms.Screen.FromHandle(new WindowInteropHelper(this).Handle);
            LockPlace();
        }
        private void LockPlace()
        {
            this.Left = Screen.WorkingArea.X + (Screen.WorkingArea.Width - 190);
            this.Top = Screen.WorkingArea.Y + (Screen.WorkingArea.Height - ActualHeight);
            CommandPanel.Visibility = Visibility.Hidden;
            WaitGrid.Visibility = Visibility.Visible;
            OpenGrid.Visibility = Visibility.Collapsed;
        }

        private void BtClose_Click(object sender, RoutedEventArgs e) => Close();

        private void BtOpen_Click(object sender, RoutedEventArgs e)
        {
            WaitGrid.Visibility = Visibility.Collapsed;
            OpenGrid.Visibility = Visibility.Visible;
            DoubleAnimation leftAni = new DoubleAnimation();
            leftAni.To = (Screen.WorkingArea.Width - ActualWidth) / 2;
            leftAni.Duration = TimeSpan.FromMilliseconds(500);
            DoubleAnimation topAni = new DoubleAnimation();
            topAni.Duration = TimeSpan.FromMilliseconds(500);
            topAni.To = (Screen.WorkingArea.Height - ActualHeight) / 2;
            this.BeginAnimation(Window.LeftProperty, leftAni);
            this.BeginAnimation(Window.TopProperty, topAni);
        }

        private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            CommandPanel.Visibility = CommandPanel.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtFunc_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Window win = WinFactory.GetWindow((sender as Button).Content.ToString());
            win.ShowDialog();
            this.Visibility = Visibility.Visible;
        }

        private void BtBack_Click(object sender, RoutedEventArgs e)
        {
            BeginAnimation(LeftProperty, null);
            BeginAnimation(TopProperty, null);
            LockPlace();
        }
    }
}
