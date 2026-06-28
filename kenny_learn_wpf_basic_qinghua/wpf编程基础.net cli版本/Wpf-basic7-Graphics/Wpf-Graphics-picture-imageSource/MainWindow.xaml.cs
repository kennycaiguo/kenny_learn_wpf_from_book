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

namespace Wpf_Graphics_picture_imageSource
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //string imgPath = Environment.CurrentDirectory + "\\sky.jpg";
            //BitmapFrame frame = BitmapFrame.Create(new Uri(imgPath));
            //CroppedBitmap crop = new CroppedBitmap();
            //crop.BeginInit();
            //crop.Source = frame;
            //crop.SourceRect = new Int32Rect(100, 150, 400, 250);
            //crop.EndInit();
            //FormatConvertedBitmap bitmap = new FormatConvertedBitmap();
            //bitmap.BeginInit();
            //bitmap.Source = crop;
            //bitmap.DestinationFormat = PixelFormats.BlackWhite;
            //bitmap.EndInit();
            //Image img = new Image();
            //img.Source = bitmap;
            //this.Content= img;
            //Window w = new Window();
            //w.Content = img;
            //w.Title = "ImageSourceChannel";
            //w.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Image croppedImage = new Image();
            croppedImage.Width = 200;
            croppedImage.Margin = new Thickness(5);

            CroppedBitmap cb = new CroppedBitmap((BitmapSource)this.Resources["masterImage"],
                new Int32Rect(30, 20, 105, 50));
            croppedImage.Source = cb;

            Image chainImage = new Image();
            chainImage.Width = 200;

            CroppedBitmap chained = new CroppedBitmap(cb, new Int32Rect(30, 0, (int)cb.Width - 30, 
                (int)cb.Height));
            chainImage.Source = chained;
            Content = chainImage;
        }
    }
}