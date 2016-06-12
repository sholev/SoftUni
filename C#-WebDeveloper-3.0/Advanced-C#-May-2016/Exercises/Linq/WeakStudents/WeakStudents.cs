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

        public string[] Marks { get; }

        public Student(string firstName, string lastName, string[] marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Marks = marks;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }

    class WeakStudents
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
                var marks = parameters.Skip(2).ToArray();

                students.Add(new Student(name, lastName, marks));
            }

            var result = from student in students
                         where student.Marks.Count(m => m == "3" || m == "2") > 1
                         select student;

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
