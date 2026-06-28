using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_animation_with_text
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Storyboard perChar = new Storyboard();
            textBlock1.TextEffects = new TextEffectCollection();
            for (int i = 0; i < textBlock1.Text.Length; i++)
            {
                TextEffect te = new TextEffect();
                te.Transform = new TranslateTransform();
                te.PositionStart = i;
                te.PositionCount = 1;
                textBlock1.TextEffects.Add(te);
                DoubleAnimation da = new DoubleAnimation();
                da.To = 9;
                da.AccelerationRatio = 0.5;
                da.DecelerationRatio = 0.5;
                da.RepeatBehavior = RepeatBehavior.Forever;
                da.AutoReverse = true;
                da.Duration = TimeSpan.FromSeconds(2);
                da.BeginTime = TimeSpan.FromMilliseconds(250 * i);
                Storyboard.SetTargetProperty(da, new PropertyPath("TextEffects[" + i + "].Transform.Y"));
                Storyboard.SetTargetName(da, textBlock1.Name);
                perChar.Children.Add(da);
            }
            perChar.Begin(this);
        }
    }
}