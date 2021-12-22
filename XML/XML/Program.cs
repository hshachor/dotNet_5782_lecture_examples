using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XML
{
    public struct Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Grade { get; set; }

    }
    class Program
    {
        static void save(List<Student> studs)
        {
            FileStream FS = new("students.xml", FileMode.Create);
            XmlSerializer x = new(studs.GetType());
            x.Serialize(FS, studs);
            FS.Close();
        }
        static void Main(string[] args)
        {
            List<Student> l = new();
            l.Add(new Student() { Grade = 1, Id = 12345678, Name = "Moshe" });
            l.Add(new Student() { Grade = 1, Id = 23456789, Name = "David" }); 
            l.Add(new Student() { Grade = 1, Id = 34567890, Name = "Shlomo" });
            save(l);
        }
    }
}
