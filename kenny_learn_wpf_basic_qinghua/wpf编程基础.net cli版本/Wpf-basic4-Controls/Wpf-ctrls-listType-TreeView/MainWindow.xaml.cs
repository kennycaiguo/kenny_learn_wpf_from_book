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

namespace Wpf_ctrls_listType_TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TreeViewItem ti = new TreeViewItem() { Header="北京"};
            TreeViewItem ti1 = new TreeViewItem() { Header="故宫"};
            ti1.Items.Add("南大门");
            ti1.Items.Add("神武门");
            ti1.Items.Add("东华门");
            ti1.Items.Add("西华门");
            ti.Items.Add(ti1);
            ti.Items.Add("颐和园");
            ti.Items.Add("水立方");
            tv.Items.Add(ti);
        }
    }
}