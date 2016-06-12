namespace Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Student
    {
        public string FirstName { get; }

        public string LastName { get; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }

    class SortStudents
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var parameters = Regex.Split(input, "\\s+");
                var name = parameters[0];
                var lastName = parameters[1];

                students.Add(new Student(name, lastName));
            }

            var result = from student in students
                         orderby student.LastName ascending, student.FirstName descending
                         select student;

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
