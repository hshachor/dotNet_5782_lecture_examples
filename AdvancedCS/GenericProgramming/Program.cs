using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericProgramming
{
    class MyGenericClass<T, U> where T: IComparable<T>
                                 where U : T
    {
        T myField;
        public void myFunction(T parm1, T parm2) {
            if (parm1.CompareTo(parm2) > 0)
            {
                T t = default;
            }
        }
    }
    class Program
    {
        static void myFunc<T, U>(T parm1, U parm2) { /* do something */ }

        static void Main(string[] args)
        {
            MyGenericClass<string, string> myObject = new();
            myObject.myFunction(1, 'a');
            
            myFunc<int, char>(2, 'a');
            myFunc(2, 'a');

            //--------------------------------
            ArrayList arr = new();
            
            List<int> list = new();
            list.Sort();
            
        }
    }
}
