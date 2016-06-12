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

        public string Phone { get; }

        public Student(string firstName, string lastName, string phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }

    class FilterStudentsByPhone
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
                var phone = parameters[2];

                students.Add(new Student(name, lastName, phone));
            }

            var result = from student in students
                         where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592")
                         select student;

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
