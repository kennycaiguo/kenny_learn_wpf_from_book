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

namespace Wpf_animation_AnimationType__path
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

        private void AnimationButton_Click(object sender, RoutedEventArgs e)
        {
            //创建路径几何体
            PathGeometry pg1 = new PathGeometry();
            //把在xaml里面定义的椭圆几何体添加进来
            pg1.AddGeometry(e1);
            ma1.PathGeometry = pg1;
            sb1.Begin(ellipse1); //StoryBoard开始路径动画

        }
    }
}