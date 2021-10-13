using System;

namespace CtorsAndDtors
{
    class A
    {
        public A() { Console.WriteLine("initializing an instance of A."); }
        static A() { Console.WriteLine("initializing class A."); }

        ~A() { Console.WriteLine("destructor of an A instance"); }
        
    }

    class B
    {
        public int Z; // zero init
        public int F = 1; // first init
        public B() { }
        public B(int val) => F = val; // short notation, second init
    }

    struct C
    {
        public int F;
        public int G;

        public C(int f, int g) { F = f; G = g; } // OK
        // compile errors:
        // public C() { F = 1; G = 2; } // cannot change default ctor!
        // public C(int f) { F = f; } // ctor must assign value to G!
    }
    class Program
    {
        static void ctorOrder()
        {
            A a;
            Console.WriteLine("we already defined reference to A but didn't created an instance.");
            a = new();
            Console.WriteLine("we now exit the function and instance of a should be freed");
        }

        static void initOrder()
        {
            B b = new(); // default ctor don't change F.
            Console.WriteLine(b.Z); // from zero init.
            Console.WriteLine(b.F); // from first init
            B b2 = new(2);
            Console.WriteLine(b2.F); // from second init
            B b3 = new(2) { F = 3 };
            Console.WriteLine(b3.F); // from third init
        }
        private static void f(C c)
        {

        }
        private static void initStruct()
        {
            C c; // ok, uninitialized
            // Console.WriteLine(c.F); // error, uninitilized.
            c.F = 5;
            Console.WriteLine(c.F);
            // Console.WriteLine(c.G); // error, although F is initialize, but G isn't
            //f(c); // error, c is only partly initialized, cannot be sent to f.
            c.G = 4;
            f(c); // once we initialized all fields, it's ok, even if no ctor was called.

            C c1 = new(); // default ctor
            f(c1); // ok
            C c2 = new(5, 6); // programmer defined ctor
            f(c2); // ok
        }

        static void Main(string[] args)
        {
            ctorOrder();
            Console.WriteLine("after exiting ctorOrder()...");
            initOrder();
            initStruct();
        }

    }
}
