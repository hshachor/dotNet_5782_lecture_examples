using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Grouping
{
    class Student
    {
        public string Name { get; init; }
        public int Id { get; init; }
        public int Grade { get; init; }
        public override string ToString() => $"Id: {Id}, Name: {Name}, Grade: {Grade}";
    }
    class FirstLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value as string;
            return s[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class GradeConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)value / 10;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Student> l = new();
            l.Add(new() { Name = "Amos", Id = 123, Grade = 95 });
            l.Add(new() { Name = "Avraham", Id = 234, Grade = 85 });
            l.Add(new() { Name = "Beni", Id = 345, Grade = 94 });
            l.Add(new() { Name = "Baruch", Id = 456, Grade = 84 });
            l.Add(new() { Name = "David", Id = 567, Grade = 75 });
            DataContext = l;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lview.ItemsSource);
                view.GroupDescriptions.Clear();
                switch ((group.SelectedItem as ComboBoxItem).Content as string)
                {
                    case "No Group":
                        break;
                    case "By Name":
                        PropertyGroupDescription groupDescription = new("Name", new FirstLetterConverter());
                        view.GroupDescriptions.Add(groupDescription);
                        break;
                    case "By Grade":
                        PropertyGroupDescription groupDescription1 = new("Grade", new GradeConveter());
                        view.GroupDescriptions.Add(groupDescription1);
                        break;
                }
            } catch { }
        }
    }
}
