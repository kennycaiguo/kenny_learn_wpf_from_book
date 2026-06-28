using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_ctrls_builder_ctrls
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

        double _startLeft;
        double _startTop;

        private void ThumdStart(object sender, DragStartedEventArgs e) //这个函数的主要作用是获取起点坐标
        {
            _startLeft = Canvas.GetLeft(thumd1);
            _startTop = Canvas.GetTop(thumd1);
        }
        private void ThumdMove(object sender, DragDeltaEventArgs e)
        {
            double left = _startLeft + e.HorizontalChange;
            double top = _startTop + e.VerticalChange;
            Canvas.SetLeft(thumd1, left);
            Canvas.SetTop(thumd1, top);
        }
        //点击按钮弹出或者取消弹出Popup控件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = !popup.IsOpen;
        }
        private void AddItem(object sender, RoutedEventArgs e) 
        {
            list1.Items.Add(toAdd.Text);
        }

        //下面这两段代码有问题
        //private void GridMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    base.DragMove();
        //}
        //private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)   
        //{
        //    base.DragMove();
        //}

    }
}