using System;

namespace AbstractClass
{
    abstract class AbsClass
    {
        abstract public void F();
        public void G() { Console.WriteLine("hello"); }
    }
    class ImpClass : AbsClass
    {
        public override void F()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbsClass abs;
            //abs = new();
            abs = new ImpClass();
            abs.G();
        }
    }
}
