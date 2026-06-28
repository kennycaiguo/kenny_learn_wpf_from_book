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

namespace Wpf_ctrls_listType_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        /// 定义属性
        public ObservableCollection<object> observableObj;
        public MainWindow()
        {
            InitializeComponent();
            observableObj = new ObservableCollection<object>();
            observableObj.Add(new { Name="贾宝玉", Gender="男",RoomName="怡红院"});
            observableObj.Add(new { Name="林黛玉", Gender="女",RoomName="潇湘馆"});
            observableObj.Add(new { Name="薛宝钗", Gender="女",RoomName="横屋苑"});
            observableObj.Add(new { Name="贾迎春", Gender="女",RoomName="紫菱洲"});
            observableObj.Add(new { Name="贾探春", Gender="女",RoomName="秋爽斋"});
            observableObj.Add(new { Name="贾惜春", Gender="女",RoomName="暖香坞"});
            observableObj.Add(new { Name="妙玉", Gender="女",RoomName="栊翠庵"});
            observableObj.Add(new { Name="李执", Gender="女",RoomName="稻香村"});
            lv.DataContext = observableObj;
        }
    }
}