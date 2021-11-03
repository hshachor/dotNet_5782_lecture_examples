using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterator
{
    class BadRange: IEnumerator, IEnumerable
    {
        int curr = -1;
        int maxVal;
        public object Current => curr;
        public bool MoveNext()
        {
            curr++;
            return curr < maxVal;
        }

        public void Reset()
        {
            curr = -1;
        }

        public IEnumerator GetEnumerator() => this;

        public BadRange(int N) { maxVal = N; }

    }

    class Range : IEnumerable, IEnumerable<int>
    {
        class MyEnumerator : IEnumerator, IEnumerator<int>
        {
            int curr = -1;
            int maxVal;
            public MyEnumerator(int N) { maxVal = N; }
            public object Current => curr;

            int IEnumerator<int>.Current => curr;

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                curr++;
                return curr < maxVal;
            }

            public void Reset()
            {
                throw new NotImplementedException(); // or: curr = 0;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(maxVal);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return new MyEnumerator(maxVal);
        }

        int maxVal;
        public Range(int N) { maxVal = N; }
    }

    class MyCollection : IEnumerable
    {
        List<int> data;

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)data).GetEnumerator();
        }
    }
    

    
    class Program
    {
        static IEnumerable rangeFunc(int maxVal)
        {
            Console.WriteLine("start run of rangeFunc");
            for (int i = 0; i < maxVal; ++i)
            {
                Console.WriteLine($"rangeFunc: i = {i}, before yield");
                yield return i;
                Console.WriteLine($"rangeFunc: i = {i}, after yield");
            }
            Console.WriteLine("range func run ends now.");
        }
        static IEnumerable smallRange()
        {
            yield return 0;
            yield return 1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("start program");
            IEnumerable r = smallRange();
            Console.WriteLine("after call to rangeFunc");
            IEnumerator it = r.GetEnumerator();
            Console.WriteLine("iterarot was created");
            while (it.MoveNext())
            {
                Console.WriteLine(it.Current);
            }
            foreach (object v in r)
            {
                Console.WriteLine(v);
            }
            
        }
    }
}
