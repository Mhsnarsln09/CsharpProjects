using System;
using LinqTraining.DbOperations;
using LinqTraining.Entities;

namespace LinqTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            // FirstOrDefault() - Returns the first element of a sequence that satisfies a condition or a default value if no such element is found
            var student = students.FirstOrDefault(s => s.Name == "Ali");
            Console.WriteLine($"Student: {student.Name} {student.Surname}");

            // SingleOrDefault() - Throws an exception if there is more than one element
            var student2 = students.SingleOrDefault(s => s.Name == "Ali");
            Console.WriteLine($"Student: {student2.Name} {student2.Surname}");

            // Find() - Searches for an entity with the given primary key values
            var studentWhere = _context.Students.Where(s => s.StudentId == 3).FirstOrDefault();
            Console.WriteLine($"Student: {studentWhere.Name} {studentWhere.Surname}");
            var student3 = _context.Students.Find(1);
            Console.WriteLine($"Student: {student3.Name} {student3.Surname}");

            // ToList() - Creates a List<T> from an IEnumerable<T>
            var studentsList = _context.Students.Where(s => s.ClassId == 1).ToList();
            foreach (var item in studentsList)
            {
                Console.WriteLine($"Student: {item.Name} {item.Surname}");
            }

            // OrderBy() - Sorts the elements of a sequence in ascending order
            var studentsOrderBy = _context.Students.OrderBy(s => s.Name).ToList();
            foreach (var item in studentsOrderBy)
            {
                Console.WriteLine($"Student: {item.Name} {item.Surname}");
            }

            // OrderByDescending() - Sorts the elements of a sequence in descending order
            var studentsOrderByDescending = _context.Students.OrderByDescending(s => s.Name).ToList();
            foreach (var item in studentsOrderByDescending)
            {
                Console.WriteLine($"Student: {item.Name} {item.Surname}");
            }

            // Anonymous Type  
            var studentsAnonymous = _context.Students.Where(s => s.ClassId == 1)
            .Select(s => new { Id = s.StudentId, FullName= $"{s.Name} {s.Surname}" });
            foreach (var item in studentsAnonymous)
            {
                Console.WriteLine($"Student: {item.Id} {item.FullName}");
            }


        }
    }
}