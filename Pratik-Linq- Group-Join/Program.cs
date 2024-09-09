using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
}

class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Öğrenciler listesi
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
            new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
            new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 }
        };

        // Sınıflar listesi
        List<Class> classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "Matematik" },
            new Class { ClassId = 2, ClassName = "Türkçe" },
            new Class { ClassId = 3, ClassName = "Kimya" }
        };

        // Group join işlemi
        var query = from cls in classes
                    join std in students on cls.ClassId equals std.ClassId into studentGroup
                    select new
                    {
                        ClassName = cls.ClassName,
                        Students = studentGroup
                    };

        // Sonuçları ekrana yazdırma
        foreach (var item in query)
        {
            Console.WriteLine($"Sınıf: {item.ClassName}");
            foreach (var student in item.Students)
            {
                Console.WriteLine($"  Öğrenci: {student.StudentName}");
            }
        }
    }
}
