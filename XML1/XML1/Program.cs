using System;
using System.Xml.Linq;
using System.Linq;

namespace XML1
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement element = XElement.Load(@"C:\Users\hshachor\source\repos\dotNet_5782_lecture_examples\DataBinding\Converter\MainWindow.xaml");
            //Console.WriteLine(((element.LastNode as XElement).FirstNode as XElement).NextNode);
            Console.WriteLine((from x in element.Elements() 
                              where x.Name == "StackPanel"
                               select x).FirstOrDefault());
        }
    }
}
