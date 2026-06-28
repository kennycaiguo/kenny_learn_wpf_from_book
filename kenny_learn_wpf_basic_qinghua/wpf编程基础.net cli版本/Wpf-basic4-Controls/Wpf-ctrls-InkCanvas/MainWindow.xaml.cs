using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_ctrls_InkCanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //在这里设置InkCanvas的SetEnabledGestures方法
            _ink.SetEnabledGestures(new ApplicationGesture[]
            {
                ApplicationGesture.AllGestures,
            });
        }
        //InkGesture事件处理函数
        private void InkGesture(object sender, InkCanvasGestureEventArgs e) 
        {
            _look.Items.Add(e.GetGestureRecognitionResults()[0].ApplicationGesture);

        }
        private void InkCanvas_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            layover.Children.Clear();
            Brush fill = new SolidColorBrush(Color.FromArgb(150, 200, 0, 0));
            foreach (var pt in e.Stroke.StylusPoints)
            {
                double markerSize = pt.PressureFactor * 35;
                Ellipse marker = new Ellipse();
                Canvas.SetLeft(marker, pt.X - markerSize / 2);
                Canvas.SetLeft(marker, pt.Y - markerSize / 2);
                marker.Width = marker.Height = markerSize;
                marker.Fill = fill;
                layover.Children.Add(marker);
            }
        }
    }
}