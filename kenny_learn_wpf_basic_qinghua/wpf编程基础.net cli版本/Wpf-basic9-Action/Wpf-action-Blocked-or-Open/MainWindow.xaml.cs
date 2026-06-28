using System.Diagnostics;
using System.Globalization;
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

namespace Wpf_action_Blocked_or_Open
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class FileToCommandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string extext = ((FileInfo)value).Extension.ToLowerInvariant();
            if(extext ==".txt")
            {
                return MainWindow.OpenCommand;
            }
            else
            {
                return MainWindow.BlockedCommand;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public partial class MainWindow : Window
    {
        public static readonly RoutedCommand BlockedCommand = new RoutedCommand("Blocked",typeof(Window));
        public static readonly RoutedCommand OpenCommand = new RoutedCommand("Open",typeof(Window));
        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(BlockedCommand,
                delegate(object sender,ExecutedRoutedEventArgs e)
                {
                    MessageBox.Show((string)e.Parameter,"Blocked");
                }));
            CommandBindings.Add(new CommandBinding(OpenCommand,
                delegate(object sender,ExecutedRoutedEventArgs e)
                {
                    Process.Start("notepad.exe", (string)e.Parameter);

                }));
            FileInfo[] fileList = new DirectoryInfo("c:\\").GetFiles("*.*");
            listBox1.ItemsSource = fileList;
        }
    }
}