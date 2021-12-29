using System;
using System.ComponentModel;
using System.Threading;


namespace Threads
{
    class Program
    {
        static void workerLoop(BankAccount acc)
        {
            BackgroundWorker w = new();


        }
        static void quarterLoop(object acc)
        {
            BankAccount account = acc as BankAccount;
            while (!exit)
            {
                Thread.Sleep(3000);
                account.ApplyInterest();
            }
        }
        static void displayBalance(object o, ValueChangedArgs args)
        {
            Console.WriteLine($"{DateTime.Now}: old balance - {args.OldV}, new balance - {args.NewV}");
        }
        static volatile bool exit = false;
        static void classicThread()
        {
            BankAccount account = new();
            account.BalanceChanged += displayBalance;
            new Thread(quarterLoop).Start(account);
            while (!exit)
            {
                try
                {
                    Console.WriteLine("Enter 1 for deposit, 2 for withdraw, 3 to exit");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Enter amount");
                            account.Deposit(int.Parse(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Enter amount");
                            account.Withdraw(int.Parse(Console.ReadLine()));
                            break;
                        case 3:
                            exit = true;
//                            t.Join();
                            Console.WriteLine("account closed with balance of " + account.Balance);
                            break;

                    }
                }
                catch { }
            }
            
        }
        static void Main(string[] args)
        {
            classicThread();
        }
    }
}
