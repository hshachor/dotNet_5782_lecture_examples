using System;

namespace Methods
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    class Person
    {
        public string Name;
        public int id;
        public string Address;

        public Person(string name, int id, string address)
        {
            // fill and initialize
        }
    }


    class Program
    {
        private static void swap(ref Point a, ref Point b)
        {
            Point temp = a;
            a = b;
            b = temp;
        }

        private static bool tryParse(string s, out int i)
        {
            try
            {
                i = int.Parse(s);
                return true;
            }
            catch (Exception)
            {
                i = -9999;
                return false;
            }
        }

        private static int sum(string s, params int[] arr)
        {
            int s1 = 0;
            for (int i = 0; i < arr.Length; ++i)
                s1 += arr[i];
            return s1;
        }

        private static int sub(int a, int b)
        {
            return a - b;
        }

        public static void Main(string[] args)
        {
            Person p = new Person("Haim", id: 12, "Jerusalem");
            Console.WriteLine(sub(5, 4));
            Console.WriteLine(sub(b: 4, a: 5));
            
            Console.WriteLine(sum(""));
            Console.WriteLine(sum("", 1, 2));
            Console.WriteLine(sum("", 1, 2, 3, 4, 6, 7, 8, 6));

            int i;
            Console.WriteLine(tryParse("456a", out i));
            Console.WriteLine(i);

            Point p1 = new Point { X = 5, Y = 6 };
            Point p2 = new Point { X = 10, Y = 1 };

            Console.Write(p1);
            Console.WriteLine(p2);
            swap(ref p1, ref p2);
            Console.Write(p1);
            Console.WriteLine(p2);

        }
    }
}
