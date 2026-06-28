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
using System.Xml.Linq;

namespace Wpf_Rounte_event_mechanism
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //如果事件不会传递,就添加这些代码
            //gridYellow.AddHandler(UIElement.MouseUpEvent,
            //    new MouseButtonEventHandler(Grid_MouseUp));
            //gridRed.AddHandler(UIElement.MouseUpEvent,
            //    new MouseButtonEventHandler(Grid_MouseUp));
            //bottomStack.AddHandler(UIElement.MouseUpEvent,
            //    new MouseButtonEventHandler(bottomStack_MouseUp));
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Grid? g = sender as Grid;
            MessageBox.Show($"{g?.Name}被点击");
            
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Window被点击");
            MessageBox.Show("如事件结束");
        }

        private void bottomStack_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StackPanel? stack = sender as StackPanel;
            MessageBox.Show(stack?.Name + "被点击");
        }

        private void buttomButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(((Button)sender).Name+"被点击");
        }

        private void topButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(sender.GetType().ToString());
        }
    }
}