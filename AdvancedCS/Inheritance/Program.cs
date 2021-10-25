using System;

namespace Inheritance
{
    //sealed
    class Parent 
    {
        public int X;
        public Parent(/*int x*/) { X = 10; }
    }

    class Child : Parent
    {
        //public int X;
        public Child() { 
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
            Parent p1 = new();
            Console.WriteLine(p1.GetType());
            Child c2 = p1 as Child;  // null!
            Console.WriteLine(c2);
            c2 ??= p as Child;
            Console.WriteLine(c2);
        }
    }
}
