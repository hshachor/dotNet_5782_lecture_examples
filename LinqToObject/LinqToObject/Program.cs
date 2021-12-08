using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObject
{
    class Program
    {
        static IEnumerable<int> foo()
        {
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(i + " ");
                yield return i % 3;
            }
        }
        static void printEnumerable(IEnumerable e)
        {
            foreach (var o in e)
            {
                if (o is IGrouping<int, string>)
                {
                    Console.WriteLine((o as IGrouping<int, string>).Key);
                    printEnumerable(o as IEnumerable);
                }
                else
                {
                    Console.Write("" + o + " ");
                }
            }
            Console.WriteLine();
        }

        static IEnumerable<int> filterOdd(IEnumerable<int> e, Predicate<int> pred)
        {
            foreach (int i in e)
            {
                if (pred(i))
                {
                    yield return i;
                }
            }
        }

        static void Main(string[] args)
        {
            var a = foo().Reverse().FirstOrDefault();
            return;
            printEnumerable(foo().Distinct());
            return;
            int i = (from n in foo()
                     select n).Sum();
            return;

            IEnumerable<int> e = new List<int>() { 2, 3, 4, 6, 8, 9};
            printEnumerable(e);
            printEnumerable(filterOdd(e, x => x%2 == 1));
            printEnumerable(e.Where(x => x%2 == 1));
            string[] children = { "Rami", "Sarit", "Eliora", "Hananel", "Efrat" };
            var result = children.SelectMany(c => c.ToArray());
            printEnumerable(result);
            var arr = from c in children
                      group c by c.Length;
            printEnumerable(arr);

        }
    }
}
