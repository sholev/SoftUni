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

        public int Age { get; }

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Age}";
        }
    }

    class StudentsByAge
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
                var age = int.Parse(parameters[2]);

                students.Add(new Student(name, lastName, age));
            }

            var result = from student in students
                         where student.Age >= 18 && student.Age <= 24
                         select student;

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
