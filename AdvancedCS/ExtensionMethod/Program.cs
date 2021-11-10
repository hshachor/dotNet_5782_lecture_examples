using System;
using System.Reflection;

namespace solid90a
{
    /// <summary>
    /// דוגמא לפונקציית הרחבה
    /// </summary>
    static class StaticTools
    {
        #region toInt
        /// <summary>
        /// replace int.Parse with string extension method
        /// </summary>
        /// <param name="str">string to parse</param>
        /// <returns>numeric representation</returns>
        public static int ToInt2(this string str)
        {
            return int.Parse(str);
        }
        #endregion
        #region tostringproperty
        public static string ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            return str;
        }
        #endregion
    }
    class Tools
    {
        public static int ToInt1(string str)
        {
            return int.Parse(str);
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            string s = "434";

            int x = Tools.ToInt1(s);

            int y = s.ToInt2();
            Console.WriteLine("445".ToInt2());
            "abcd".GetHashCode();
            Console.WriteLine(DateTime.Now.ToStringProperty());
        }
    }


}
