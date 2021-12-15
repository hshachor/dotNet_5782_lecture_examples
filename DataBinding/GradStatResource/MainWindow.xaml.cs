using System.Windows;
using System.Windows.Media;

namespace GradStatResource
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = Resources["myLinearGradientBrush"] as LinearGradientBrush;
            a.GradientStops[0].Color = Colors.Black;

        }
    }
}
