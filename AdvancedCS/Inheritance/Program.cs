using System;

namespace Inheritance
{
    //sealed 
    class Parent 
    {
        public int X;
        public Parent(int x) { X = x; }
    }

    class Child : Parent
    {
        public int X = 0;
        public Child() : base(10) 
        { 
            /*
            Console.WriteLine(X); 
            Console.WriteLine(base.X); 
            */
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Child c = new();
            Parent p = c;           // ok, upcast
            //Child c1 = p;         // error, downcast
            Child c1 = (Child)p;    // ok, explicit cast
            Console.WriteLine(p.GetType());
            if (p is Child) { }
            Console.WriteLine("Q. p is child?\n A. " + (p is Child));
            Parent p1 = new(10);
            Console.WriteLine(p1.GetType());
            Child c2 = p1 as Child;  // null!
            Console.WriteLine(c2);
            c2 ??= p as Child;
            Console.WriteLine(c2);
        }
    }
}
