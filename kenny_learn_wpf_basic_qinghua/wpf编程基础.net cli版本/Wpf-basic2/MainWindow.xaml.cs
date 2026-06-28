using System.ComponentModel;
using System.Globalization;
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

namespace Wpf_basic2
{
    //Teacher类
    [TypeConverterAttribute(typeof(StringToTeacherConverter))]//使用转换器注解
    public class Teacher
    {
        public string Name { get; set; }
        public Teacher Student { get; set; }
    }

    //转换类
    public class StringToTeacherConverter:TypeConverter
    {
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if(value is string)
            {
                Teacher t = new Teacher();
                t.Name = value as string;
                return t;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Rectangle Clicked!!");
        }

        private void OnClicked(object sender, MouseButtonEventArgs e)
        {
            Teacher t = (Teacher)this.FindResource("teacher");
            MessageBox.Show(t.Student.Name);
        }

    }
}