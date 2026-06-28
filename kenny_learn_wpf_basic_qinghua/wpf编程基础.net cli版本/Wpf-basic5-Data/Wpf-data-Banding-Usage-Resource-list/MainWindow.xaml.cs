using System.Collections.ObjectModel;
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

namespace Wpf_data_Banding_Usage_Resource_list
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //User类
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
        public User() { }
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
            if (!int.TryParse((string)value, out number)) //1.检查数据格式,人的年龄是整数
            {
                return new ValidationResult(false, "Invalid Number Format");
            }
            if (number < min || number > max) //2.判断时候出界
            {
                return new ValidationResult(false, $"Humam age should between {min}and{max}");
            }
            return ValidationResult.ValidResult; //3.没有问题就验证通过
        }
    }
    //使用User作为数据的集合类
    public class Users:ObservableCollection<User>
    {

    }
    public partial class MainWindow : Window
    {
        ICollectionView GetUsersetView()
        {
            Users users = (Users)FindResource("Userset");
            return CollectionViewSource.GetDefaultView(users);
        }
        User user = new User();
        List<User> list = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void firstButton_Click(object sender, RoutedEventArgs e)
        {
            if(userListBox.SelectedItem!=null)
            {
                userListBox.SelectedIndex = 0;
            }
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetUsersetView();
            view.MoveCurrentToPrevious();
            if(view.IsCurrentBeforeFirst)//移动了需要判断
            {
                view.MoveCurrentToFirst();//到达第一个元素了就不能够再往前移动了超过了第一个,需要移动回第一个
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = GetUsersetView();
            view.MoveCurrentToNext();
            if(view.IsCurrentAfterLast)
            {
                view.MoveCurrentToLast();//到达最后一个元素了就不能够再往后移动了超过了最后一个,需要移动回最后一个
            }
        }

        private void lastButton_Click(object sender, RoutedEventArgs e)
        {
            if (userListBox.SelectedItem != null)
            {
                userListBox.SelectedIndex = userListBox.Items.Count - 1;
            }
        }
    }
}