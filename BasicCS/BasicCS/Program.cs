using System;

namespace BasicCS
{
    class A
    {
        public int b;
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A(); // or new() - find automatically the type.
            A a1 = a;
            Console.WriteLine(a.b);
            a1.b = 1;
            Console.WriteLine(a.b);

            /*
            a.
            A.
             */
        }
    }
}
