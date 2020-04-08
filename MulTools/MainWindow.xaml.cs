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
        }
    }
}
