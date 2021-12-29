using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        volatile bool exit = false;
        void quarterLoop()
        {
            while (!exit)
            {
                Thread.Sleep(3000);
                account.ApplyInterest();
            }
            Dispatcher.Invoke(() => txtBalance.Text = "Closing...");
        }
        Threads.BankAccount account;
        public MainWindow()
        {
            InitializeComponent();
            account = new();
            account.BalanceChanged += handleBalanceDisplay;
            new Thread(quarterLoop).Start();
        }

        private void handleBalanceDisplay(object o, EventArgs e)
        {
            updateBalance();
        }

        private void updateBalance()
        {
            if (CheckAccess())
            {
                Thread.Sleep(1000);
                txtBalance.Text = account.Balance.ToString();
            }
            else
            {
                Dispatcher.Invoke(updateBalance);
            }
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            account.Deposit(int.Parse(txtAmount.Text));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            exit = true;
            Thread.Sleep(5000);
            Close();
        }
    }
}
