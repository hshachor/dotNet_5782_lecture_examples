using System;
using System.Reflection;

namespace Exceptions
{
    class Program
    {
        class MyClass
        {
            public int Id;
            public int Name;
        }

        static void PrintInfo(Type type)
        {

            Console.WriteLine("Type Name: " + type.Name);
            Console.WriteLine("Base Type: " + type.BaseType);

            Console.WriteLine("MethodInfo:");
            MethodInfo[] info = type.GetMethods();
            foreach (var item in info)
                Console.WriteLine("name: {0,-15} Declaring in: {1} ",
                                  item.Name, item.DeclaringType.Name);
        }

        static void Main(string[] args)
        {
            PrintInfo(typeof(MyClass));
            Console.WriteLine("---------------");
            var a = new { id = 2222,  Name = "Yossi"};
            var a1 = new { id = 2222, Name = "Yossi" };
            var b = new { id = 2223, Name = "Ydsgadgossi" };
            PrintInfo(a.GetType());
            PrintInfo(b.GetType());
            Console.WriteLine(a == a1);
            Console.WriteLine(a.Equals(a1));
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(a1.GetHashCode());
            Console.WriteLine(a == b);
            /*
            Console.WriteLine(a.);
            Console.WriteLine(a.GetType());
            Console.WriteLine(a.GetType().GetMethods());
            */
            return;
            Console.WriteLine(int.Parse("123456789012345678901234567890"));
            throw new Exception();
        }
    }
}
