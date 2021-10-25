using System;

namespace Polymorphism
{
    class GrandParent
    {
        public virtual void F() { Console.WriteLine("GP.F"); }
        public virtual void G() { Console.WriteLine("GP.G"); }

        public override string ToString()
        {
            return "GrandParent";
        }
    }

    class Parent : GrandParent
    {
        public override void F() { Console.WriteLine("P.F"); }
        public new void G() { Console.WriteLine("P.G"); }
        public new string ToString() => "Parent";
        

    }

    class Child : Parent
    {
        public override void F() { Console.WriteLine("C.F"); }
        public /*override*/ void G() => Console.WriteLine("C.G"); 
        public string ToString() => "Child";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child c = new();
            // F on Child instance:
            c.F();
            (c as Parent).F();
            (c as GrandParent).F();

            // G on Child instance:
            c.G();
            (c as Parent).G();
            (c as GrandParent).G();

            // What happens here?
            Console.WriteLine(c);
            Console.WriteLine(c.ToString()); 

        }
    }
}
