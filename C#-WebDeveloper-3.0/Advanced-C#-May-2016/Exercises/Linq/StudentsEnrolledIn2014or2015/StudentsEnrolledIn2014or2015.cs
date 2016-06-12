namespace Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Student
    {
        public string EnrollmentDate { get; }

        public string[] Marks { get; }

        public Student(string enrollmentDate, string[] marks)
        {
            this.EnrollmentDate = enrollmentDate;
            this.Marks = marks;
        }

        public override string ToString()
        {
            return $"{string.Join(" ", this.Marks)}";
        }
    }

    class StudentsEnrolledIn2014or2015
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var parameters = Regex.Split(input, "\\s+");
                var enrollDate = parameters[0];
                var marks = parameters.Skip(1).ToArray();

                students.Add(new Student(enrollDate, marks));
            }

            var result = from student in students
                         where student.EnrollmentDate.EndsWith("14") || student.EnrollmentDate.EndsWith("15")
                         select student;

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
