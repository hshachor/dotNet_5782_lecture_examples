using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            // or:
            int[] arr1 = { 1, 2, 3, 4 };
            int[] arr2 = new int[] { 1, 2, 3 };

            for (int i = 0; i < 10; ++i)
            {
                arr[i] = i;
                Console.WriteLine(arr[i]);
            }

            int[] arr4 = arr; // reference assignment
            
            // self learn:
            int[][] arrayOfArray;
            int[,] matrix;


        }
    }
}
