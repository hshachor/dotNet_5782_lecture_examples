using System;

namespace AbstractClass
{
    abstract class AbsClass
    {
        abstract public void F();
    }
    class ImpClass : AbsClass
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbsClass abs;
            //abs = new();
            abs = new ImpClass();
        }
    }
}
