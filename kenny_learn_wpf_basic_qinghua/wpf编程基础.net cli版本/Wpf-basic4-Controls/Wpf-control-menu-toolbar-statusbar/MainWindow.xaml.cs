using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_control_menu_toolbar_statusbar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void OpenClicked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Open Menu item click");
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "文本文件|*.txt|图片|*.jpg|所有文件|*.*";
            if (dlg.ShowDialog() == true) 
            {
                MessageBox.Show(dlg.FileName);
            }
        }
        public void ExitClicked(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.OK == MessageBox.Show("Exit?","Confirm",MessageBoxButton.OKCancel))
            {
                Close();//关闭程序
            }
        }
    }
}