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

        public int Group { get; }

        public Student(string firstName, string lastName, int group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Group = group;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }

    class GroupByGroup
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
                var group = int.Parse(parameters[2]);

                students.Add(new Student(name, lastName, group));
            }

            // Couldn't figure this out.
            //var result = from student in students
            //             group students by student.Group
            //             into student
            //             select student;

            var result = students.GroupBy(s => s.Group).OrderBy(g => g.Key);

            foreach (var entry in result)
            {
                Console.WriteLine($"{entry.Key} - {string.Join(", ", entry)}");
            }
        }
    }
}
