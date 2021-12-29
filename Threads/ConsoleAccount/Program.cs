using System;

namespace Threads
{
    class Program
    {
        static void displayBalance(object o, ValueChangedArgs args)
        {
            Console.WriteLine($"{DateTime.Now}: old balance - {args.OldV}, new balance - {args.NewV}");
        }
        static void classicThread()
        {
            BankAccount account = new();
            account.BalanceChanged += displayBalance;
            bool exit = false;
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
