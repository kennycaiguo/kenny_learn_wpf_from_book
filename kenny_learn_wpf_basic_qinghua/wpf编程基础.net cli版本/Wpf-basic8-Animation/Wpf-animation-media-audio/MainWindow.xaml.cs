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

namespace Wpf_animation_media_audio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaTimeline audioTL;
        MediaClock audioC; 
        public MainWindow()
        {
            InitializeComponent();
            string path = Environment.CurrentDirectory + "\\hello.mp3";
            audioTL = new MediaTimeline();
            audioTL.Source = new Uri(path);
            audioC = audioTL.CreateClock();
            MediaPlayer player = new MediaPlayer();
            player.Clock = audioC;
            audioC.CurrentTimeInvalidated += TimeChanged;
            audioC.Controller.Begin();
        }

        void TimeChanged(object sender,EventArgs e)
        {
            Title = audioC.CurrentTime.ToString();
        }
    }
}