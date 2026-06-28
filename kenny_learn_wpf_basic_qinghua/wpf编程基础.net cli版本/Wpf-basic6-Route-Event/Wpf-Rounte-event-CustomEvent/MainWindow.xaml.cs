using System.Security.Cryptography.X509Certificates;
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

namespace Wpf_Rounte_event_CustomEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //自定义事件参数类RecordingTimeEventArgs类,继承值RoutedEventArgs
    public class RecordingTimeEventArgs:RoutedEventArgs
    {
        public  RecordingTimeEventArgs(RoutedEvent routedEvent,object source):
            base(routedEvent,source){}
        public DateTime ClickTime {  get; set; }
    }
     
    public class TimerButton:Button
    {
        //1.声明路由事件
        public static readonly RoutedEvent RecordingTimeEvent = EventManager.RegisterRoutedEvent(
           "RecordingTime" ,RoutingStrategy.Bubble,typeof(EventHandler<RecordingTimeEventArgs>),
           typeof(TimerButton));
        //2.CLR事件包装
        public event RoutedEventHandler RecordingTime 
        {
            add { this.AddHandler(RecordingTimeEvent, value); }
            remove { this.RemoveHandler(RecordingTimeEvent, value); }
        }
        //3.触发路由事件
        protected override void OnClick()
        {
            base.OnClick();//保证原有的功能正常使用
            RecordingTimeEventArgs args = new RecordingTimeEventArgs(RecordingTimeEvent, this);
            args.ClickTime = DateTime.Now;
            this.RaiseEvent(args);//UIElement以及他的派生类
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RecordingTimeHandler(object sender, RecordingTimeEventArgs e) 
        {
            FrameworkElement element = (FrameworkElement)sender;
            string timeStr = e.ClickTime.ToString("HH:mm:ss");
            string content = string.Format("{0}到达{1}",timeStr,element.Name);
            timeListBox.Items.Add(content);     
        }
    }
}