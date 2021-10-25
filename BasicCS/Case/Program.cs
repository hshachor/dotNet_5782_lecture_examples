using System;

namespace Case
{
    class Program
    {
        static void tupleCase(int a, int b)
        {
            switch (a, b)
            {
                case ( > 0, > 0) when a == b:
                    Console.WriteLine("a=b");
                    break;
                case ( < 0, > 0):
                    Console.WriteLine("negative product");
                    break;
            }
            Console.WriteLine(a + 2 switch {
                1 => "One", 
                2 => "Two", 
                > 2 => "Many", 
                _ => "Non-positive" 
            });
        }
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    Console.WriteLine("single argument");
                    break;
                case 2:
                    Console.WriteLine("2 arguments");
                    break;
                default:
                    Console.WriteLine("more than 2 arguments");
                    break;

            }
            tupleCase(-1, 2);
        }
    }
}

// demonstrate: 
// case 3:case 4:
// case >2