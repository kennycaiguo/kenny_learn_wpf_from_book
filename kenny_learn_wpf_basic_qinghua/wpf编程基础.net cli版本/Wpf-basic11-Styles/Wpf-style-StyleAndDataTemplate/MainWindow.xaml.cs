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
using System.Collections.ObjectModel;


namespace Wpf_style_StyleAndDataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phote { get; set; }
    }

    public class PersonCollection : Person
    {
        ObservableCollection<Person> persons = new ObservableCollection<Person>();
        public PersonCollection() 
        {
            persons.Add(
                new Person
                {
                    Name="客服小妹",
                    Phote = "/Images/kfxm.jpg",
                    Address="广东东莞",
                    Gender="女"
                }); 
               persons.Add(
                new Person
                {
                    Name="环境如画",
                    Phote = "/Images/strm.png",
                    Address="湖南衡阳",
                    Gender="女"
                }); 
               persons.Add(
                new Person
                {
                    Name="千鸟之王",
                    Phote = "/Images/birds.jpg",
                    Address="四川乐山",
                    Gender="男"
                });
        }
        public ObservableCollection<Person> Persons
        {
            get
            {
                return persons;
            }
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new PersonCollection();//建立关联
        }
    }
}