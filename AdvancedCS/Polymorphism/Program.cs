using System;

namespace Polymorphism
{
    class GrandParent
    {
        public void H() { Console.WriteLine("GP.H"); }
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
        public new virtual void G() { Console.WriteLine("P.G"); }
        public new string ToString() => "Parent";
        

    }

    class Child : Parent
    {
        public void H() { Console.WriteLine("C.H"); }
        public override void F() { Console.WriteLine("C.F"); }
        public override void G() => Console.WriteLine("C.G"); 
        public string ToString() => "Child";
    }

    class Example
    {
        public override string ToString() => "some custom string";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child c = new Child();
            // F on Child instance:
            c.F();
            ((Parent) c).F();
            (c as GrandParent).F();

            // G on Child instance:
            c.G();
            (c as Parent).G();
            (c as GrandParent).G();

            c.H();
            (c as Parent).H();
            (c as GrandParent).H();

            // What happens here?
            Example o = new();
            Console.WriteLine(o);
            Console.WriteLine(o.ToString()); 

        }
    }
}
