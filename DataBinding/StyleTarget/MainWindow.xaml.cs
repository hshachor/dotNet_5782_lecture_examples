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

namespace solid55
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var set = new Setter(Button.BackgroundProperty, Brushes.Yellow);
            var style = new Style(typeof(Button), this.Resources["bottunStyle"] as Style);
            style.Setters.Add(new Setter(Button.BackgroundProperty, Brushes.Yellow));
            this.Resources["bottunStyle"] = style;
//            var b = sender as Button;
//            b.Background = Brushes.Yellow;
        }
    }
}
