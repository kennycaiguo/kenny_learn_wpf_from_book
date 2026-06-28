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

namespace Wpf_controls_demo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ContentPresenter
            //StackPanel panel = new StackPanel();
            //ContentPresenter strPresenter = new ContentPresenter();
            //strPresenter.Content = "Hello WPF";
            //panel.Children.Add(strPresenter);
            //ContentPresenter datePresenter = new ContentPresenter();
            //datePresenter.Content =DateTime.Now;
            //panel.Children.Add(datePresenter); 
            //ContentPresenter elementPresenter = new ContentPresenter();
            //elementPresenter.Content = new Button();
            //panel.Children.Add(elementPresenter);
            //Content = panel;
            //Items
            //ListBox lb = new ListBox();
            //lb.Items.Add("Hello");
            //lb.Items.Add("WPF");
            //Content = lb;

        }
        public void ButtonClick(object sender,RoutedEventArgs e)
        {
            ControlTemplate template = new ControlTemplate(typeof(Button));
            template.VisualTree = new FrameworkElementFactory(typeof(Ellipse));
            template.VisualTree.SetValue(Ellipse.FillProperty, Brushes.Purple);
            template.VisualTree.SetValue(Ellipse.WidthProperty,100.0);
            template.VisualTree.SetValue(Ellipse.HeightProperty, 30.0);
            ((Button)sender).Template = template;
        }
    }
}