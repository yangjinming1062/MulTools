using System.Windows;
using System.Windows.Input;

namespace MulTools.Win
{
    /// <summary>
    /// 文件操作.xaml 的交互逻辑
    /// </summary>
    public partial class 文件操作 : Window
    {
        public 文件操作()
        {
            InitializeComponent();
        }

        private void TitleGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btClose_Click(object sender, RoutedEventArgs e) => Close();
    }
}
