using System;
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

namespace Wpf_resource_ResourceDictory
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

        private void dateButton_Click(object sender, RoutedEventArgs e)
        {
            dateTextBox.Text = this.FindResource("str1").ToString();
        }

        private void timeButton_Click(object sender, RoutedEventArgs e)
        {
            timeTextBox.Text = this.FindResource("str2").ToString();
        }

        private void weatherButton_Click(object sender, RoutedEventArgs e)
        {
            wheatherTextBox.Text = this.FindResource("str3").ToString();
        }
    }
}