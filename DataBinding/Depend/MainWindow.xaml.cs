using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace solid48a
{
    public class MyData : DependencyObject
    {
        public string User
        {
            get { return (string)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User",
            typeof(string), typeof(MyData), new UIPropertyMetadata(""));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password",
            typeof(string), typeof(MyData), new UIPropertyMetadata(""));
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyData _myData;

        public MainWindow()
        {
            InitializeComponent();

            _myData = new MyData()
            {
                User = "Arik",
                Password = "123456"
            };
            stackPanel.DataContext = _myData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _myData.Password = "555555";//כעת השינוי מתרחש
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_myData.Password);
        }
    }
}
