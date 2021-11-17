using System;

namespace Dlgt
{
    public class MyPrinter
    {
        public class PrinterEventArgs : EventArgs
        {
            public readonly int missing;
            public PrinterEventArgs(int m) { missing = m; }
        }
        public event EventHandler<PrinterEventArgs> PageOver = null;
        private int pageCount = 20;
        private void handlePageOver(int miss)
        { if (PageOver != null) PageOver(this, new PrinterEventArgs(miss)); }
        public void Print(int pages)
        {
            if (pages <= pageCount) pageCount -= pages;
            else { handlePageOver(pages - pageCount); pageCount = 0; }
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
        private void myPageOver(object sender, EventArgs e)
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
        private void myPageOver(object sender, MyPrinter.PrinterEventArgs pe)
        {
            Console.WriteLine("missing paper in printer, please refil at least " + pe.missing + " pages");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            MyPrinter printer = new();
            User u1 = new(printer);
            Secretary s = new(printer);
            //printer.PageOver();
            printer.Print(21);
            return;
        }
    }

}
