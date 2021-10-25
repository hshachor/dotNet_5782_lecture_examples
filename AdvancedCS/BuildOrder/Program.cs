using System;

namespace InitOrder
{
    /// <summary>
    /// Helper class to follow init order
    /// </summary>
    class Tools
    {
        /// <summary>
        /// Print message and return given value
        /// </summary>
        /// <param name="s"> message to print </param>
        /// <param name="i"> value to return </param>
        /// <returns> the given value in param i</returns>
        static public int InitWithMessage(string s, int i = 0)
        {
            Console.WriteLine(s);
            return i;
        }
    }

    class Parent
    {
        static int StaticField = Tools.InitWithMessage("Static field of Parent class is initialized now");
        static Parent() => Console.WriteLine("Static ctor of Parent class is called now");
        public int InstanceField = Tools.InitWithMessage("Instance field of Parent class is initialized now");
        public Parent() => Console.WriteLine("Instance ctor of Parent class is called now");
    }

    class Child : Parent
    {
        static int StaticChildField = Tools.InitWithMessage("Static field of Child class is initialized now");
        static Child() => Console.WriteLine("Static ctor of Child class is called now");
        public int InstanceChildField = Tools.InitWithMessage("Instance field of Child class is initialized now");
        public Child() => Console.WriteLine("Instance ctor of Child class is called now");
    }


    class Program
    {
        static void Main(string[] args)
        {
            new Parent();
            //new Child();
        }
    }
}
