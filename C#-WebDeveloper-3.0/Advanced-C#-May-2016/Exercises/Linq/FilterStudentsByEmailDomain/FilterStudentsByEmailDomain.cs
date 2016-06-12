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

        public string Email { get; }

        public Student(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }

    class FilterStudentsByEmailDomain
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
                var email = parameters[2];

                students.Add(new Student(name, lastName, email));
            }

            var result = from student in students
                         where student.Email.EndsWith("@gmail.com")
                         select student;

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
