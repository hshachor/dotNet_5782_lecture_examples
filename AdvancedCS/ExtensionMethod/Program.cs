using System;
using System.Reflection;

namespace solid90a
{
    /// <summary>
    /// דוגמא לפונקציית הרחבה
    /// </summary>
    static class StaticTools
    {
        public static int ToInt2(this string str)
        {
            return int.Parse(str);
        }
        public static string ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
                str += "\n" + item.Name + ": " + item.GetValue(t, null);
            return str;
        }
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
            Console.WriteLine(DateTime.Now.ToStringProperty());
        }
    }


}
