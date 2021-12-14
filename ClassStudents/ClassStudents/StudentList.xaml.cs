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
using System.Windows.Shapes;

namespace ClassStudents
{
    /// <summary>
    /// Interaction logic for StudentList.xaml
    /// </summary>
    public partial class StudentList : Window
    {
        IEnumerable<Student> studs;
        public StudentList()
        {
            List<Student> myStuds = new List<Student>();
            myStuds.Add(new Student() { grade = 87, ID = 1234, Name = "משה" });
            myStuds.Add(new Student() { grade = 90, ID = 2345, Name = "מאיר" });
            studs = myStuds;
            // initialize list ...
            InitializeComponent();
            foreach (var s in studs)
            {
                ComboBoxItem newItem = new();
                newItem.Content = s.ToString() + s.ID;
                cmbStudents.Items.Add(newItem);
            }
        }

        private void lbSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox l = sender as ListBox;
        }
    }
}
