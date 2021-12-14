using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml.Linq;
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

namespace solid50
{
    public class MyData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLecturer { get; set; }

        public override string ToString()
        {
            return string.Format("First name: {0}, Last name: {1}, Is lecturer: {2}",
              FirstName, LastName, IsLecturer);
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<MyData> _myCollection = new ();

        public MainWindow()
        {
            InitializeComponent();

            _myCollection.Add(
              new MyData
              {
                  FirstName = "Arik",
                  LastName = "Poznanski",
                  IsLecturer = true
              });
            _myCollection.Add(
              new MyData
              {
                  FirstName = "John",
                  LastName = "Smith",
                  IsLecturer = false
              });
            DataContext = _myCollection;

        }

        private int counter = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ++counter;
            _myCollection.Add(
                new MyData()
                {
                    FirstName = "item " + counter,
                    LastName = "item " + counter,
                    IsLecturer = counter % 3 == 0
                });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
