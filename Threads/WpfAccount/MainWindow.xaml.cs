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
using Threads;

namespace WpfAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Threads.BankAccount account
        public MainWindow()
        {
            InitializeComponent();
            account = new();
            account.BalanceChanged += handleBalanceDisplay();
        }

        private EventHandler<ValueChangedArgs> handleBalanceDisplay()
        {
            throw new NotImplementedException();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
