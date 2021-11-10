using System;
using System.Collections.Generic;

namespace Dlgt
{
    public delegate int SomeDelegate(int x, int y);
    static class Tools
    {
        static public string MyToString<T>(this List<T> l)
        {
            string s = "";
            foreach (T item in l)
            {
                s += item + " ";
            }
            return s;
        }
    }
    public delegate void PrintEventHandler();

    public class MyPrinter
    {
        public PrintEventHandler PageOver = null;
        private int pageCount = 20;
        private void handlePageOver()
        { if (PageOver != null) PageOver(); }
        public void Print(int pages)
        {
            if (pages <= pageCount) pageCount -= pages;
            else { pageCount = 0; handlePageOver(); }
        }
    }

    class User
    {
        MyPrinter myPrinter;
        public User(MyPrinter printer)
        {
            myPrinter = printer;
            printer.PageOver += myPageOver;
        }
        private void myPageOver()
        {
            Console.WriteLine("missing paper in printer, try tommorow");
        }
    }
    class Secretary
    {
        MyPrinter myPrinter;
        public Secretary(MyPrinter printer)
        {
            myPrinter = printer;
            printer.PageOver += myPageOver;
        }
        private void myPageOver()
        {
            Console.WriteLine("missing paper in printer, please refil");
        }
    }


    class Program
    {

        
        static public int sum(int num1, int num2) { return num1 + num2; }
        static public int mult(int num1, int num2) { return num1 * num2; }
        static public int sub(int num1, int num2) { return num1 - num2; }
        static bool isEven(int i) { return (i & 1) == 0; }
        static void Main(string[] args)
        {
            MyPrinter printer = new();
            User u1 = new(printer);
            Secretary s = new(printer);
            printer.Print(25);
            return;
            List<int> l = new List<int> { 5, 3, 7, 2, 8 };
            Console.WriteLine(l.FindAll(i => (i & 1) == 0).MyToString());
            SomeDelegate myDlgt = new SomeDelegate(sum);
            myDlgt += mult; myDlgt += sub; myDlgt -= sum;

            foreach (var d in myDlgt.GetInvocationList()) Console.WriteLine(d.Method);
            if (myDlgt is Delegate) Console.WriteLine("myDlgt is Delegate == true");
            foreach (var item in myDlgt.GetInvocationList())
                Console.WriteLine(item.DynamicInvoke(3, 2));
        }
    }

}
