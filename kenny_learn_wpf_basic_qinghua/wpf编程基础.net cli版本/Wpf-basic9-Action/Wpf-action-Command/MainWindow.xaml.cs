using Microsoft.Win32;
using System.IO;
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

namespace Wpf_action_Command
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

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //如果文本框没有内容就让命令不可用
            if (textBox1.Text==string.Empty)
            {
                e.CanExecute = false;
            }
            //否则就让他可用
            else
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //弹出保存文件对话框获取保存路径和文件名
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "文本文件|*.txt|所有文件|*.*";
            if(dlg.ShowDialog()==true)
            {
                StreamWriter sw = new StreamWriter(dlg.FileName);
                sw.Write(textBox1.Text);
                sw.Close();
                MessageBox.Show("文件保存成功");
            }
        }

        private void menuExut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}