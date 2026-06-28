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
using System.ComponentModel;

namespace Wpf_data_Banding_theory_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class User:INotifyPropertyChanged
    {
        string name;
        int age;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Notify(string ProName) 
        {
            if(this.PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(ProName));
            }
        }

       
        public string Name { get { return name; } 
            set { 
                if(name == value) { return; }
                name = value;
                Notify("Name");
            } 
        }
        public int Age { get { return age; } 
            set { 
                if(age == value) { return; }
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

    public partial class MainWindow : Window
    {
        User u = new User("Jack", 8);
        void user_ProtertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name":this.nameTextBox.Text = u.Name; break;
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