using System;

namespace PL_console
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.BL bl = new BL.BL();
            Console.WriteLine(bl.GetMessage());
        }
    }
}
