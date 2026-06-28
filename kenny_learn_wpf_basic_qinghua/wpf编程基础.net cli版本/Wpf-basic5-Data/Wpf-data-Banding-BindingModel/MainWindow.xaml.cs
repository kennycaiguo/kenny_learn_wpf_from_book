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

namespace Wpf_data_Banding_BindingModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class User : INotifyPropertyChanged
    {
        string name;
        int age;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notify(string ProName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(ProName));
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) { return; }
                name = value;
                Notify("Name");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (age == value) { return; }
                age = value;
                Notify("Age");
            }
        }
        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    public class NumberRangeRule : ValidationRule
    {
        int min; //最小值
        public int Min
        {
            get { return min; }
            set { min = value; }
        }
        int max; //最大值
        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int number;
            if(!int.TryParse((string)value,out number)) //1.检查数据格式,人的年龄是整数
            {
                return new ValidationResult(false, "Invalid Number Format");
            }
            if(number<min || number>max) //2.判断时候出界
            {
                return new ValidationResult(false, $"Humam age should between {min}and{max}");
            }
            return ValidationResult.ValidResult; //3.没有问题就验证通过
        }
    }
    public partial class MainWindow : Window
    {
        User u = new User("Jack", 8);
        void user_ProtertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name": this.nameTextBox.Text = u.Name; break;
                case "Age": this.ageTextBox.Text = u.Age.ToString(); break;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            grid.DataContext = u;
            this.nameTextBox.Text = u.Name;
            this.ageTextBox.Text = u.Age.ToString();
            u.PropertyChanged += user_ProtertyChanged;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ++u.Age;
            string str = $"Name:{this.nameTextBox.Text}\n Age:{this.ageTextBox.Text}";
            MessageBox.Show(str);
        }
    }
}