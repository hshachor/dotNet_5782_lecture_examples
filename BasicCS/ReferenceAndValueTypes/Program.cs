using System;

namespace ReferenceAndValueTypes
{
    class A
    {
        public int f;
    }
    struct B
    {
        public int g;
        public int h;

    }

    class Program
    {
        static void Main(string[] args)
        {
            changeValueAfterAssignmentRefType();
            changeValueAfterAssignmentValueType();
            objectInheritance();

        }

        private static void changeValueAfterAssignmentRefType()
        {
            A a = new(); // or new() - find automatically the type.
            A a1 = a;
            Console.WriteLine("a.f before assignment of a1.f: " + a.f);
            a1.f = 1;
            Console.WriteLine("a.f after assignment of a1.f: " + a.f);
        }

        private static void changeValueAfterAssignmentValueType()
        {
            B b = new(); // or new() - find automatically the type.
            B b1 = b;
            Console.WriteLine("b.g before assignment of b1.g: " + b.g);
            b1.g = 1;
            Console.WriteLine("b.g after assignment of b1.g: " + b.g);
        }


        private static void objectInheritance()
        {
            A a = new();
            //equals:
            Console.WriteLine($"a.Equals(null): {a.Equals(null)}");
            Console.WriteLine($"a.Equals(a): {a.Equals(a)}");
            A a1 = new();
            Console.WriteLine(a.Equals(a1));

            // hashcode - as in basic object
            Console.WriteLine($"a.GetHashCode(): {a.GetHashCode()}");
            Console.WriteLine($"a1.GetHashCode(): {a1.GetHashCode()}");

            // GetType
            Console.WriteLine($"a.GetType(): {a.GetType()}");
            object o = a;
            Console.WriteLine($"o.GetType(): {o.GetType()}");
            B b = new();
            Console.WriteLine($"b.GetType(): {b.GetType()}");

            // ToString (default inherited from object)
            Console.WriteLine($"a.ToString(): {a.ToString()}");
            // but also:
            Console.WriteLine($"a/*.ToString()*/: {a}");

            // static methods:
            Console.WriteLine(A.Equals(a, b));
            Console.WriteLine(A.ReferenceEquals(a, a1));
        }


    }
}
