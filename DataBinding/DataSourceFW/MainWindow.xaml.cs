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

namespace DataSourceFW
{
    class Person
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string address { get; set; }
        public Image picture { get; set; }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource personViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // personViewSource.Source = [generic data source]
        }
    }
}
