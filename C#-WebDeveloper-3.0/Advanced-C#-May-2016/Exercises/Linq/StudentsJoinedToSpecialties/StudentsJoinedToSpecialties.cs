namespace LinqStudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Student
    {
        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public Student(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }

    public class StudentSpecialty
    {
        public string Id { get; set; }

        public string Speciality { get; set; }

        public StudentSpecialty(string id, string speciality)
        {
            this.Id = id;
            this.Speciality = speciality;
        }

        public override string ToString()
        {
            return $"{this.Speciality}";
        }
    }

    class StudentsJoinedToSpecialties
    {
        static void Main(string[] args)
        {
            string input;

            var studentSpecialties = new List<StudentSpecialty>();
            while ((input = Console.ReadLine()) != "Students:")
            {
                var parameters = Regex.Split(input, "\\s+");
                var speciality = $"{parameters[0]} {parameters[1]}";
                var id = parameters[2];

                studentSpecialties.Add(new StudentSpecialty(id, speciality));
            }

            var studentsList = new List<Student>();
            while ((input = Console.ReadLine()) != "END")
            {
                var parameters = Regex.Split(input, "\\s+");
                var id = parameters[0];
                var name = parameters[1];
                var lastName = parameters[2];

                studentsList.Add(new Student(name, lastName, id));
            }

            var output =
                studentSpecialties.GroupJoin(
                    studentsList,
                    sp => sp.Id,
                    s => s.Id,
                    (spec, students) =>
                        new
                        {
                            Specialty = spec.Speciality,
                            StudentNamesWithIds =
                            students.Select(s => $"{s.FirstName} {s.LastName} {s.Id} {spec.Speciality}")
                        })
                    .SelectMany(a => a.StudentNamesWithIds)
                    .OrderBy(s => s);

            Console.WriteLine(string.Join(Environment.NewLine, output));
        }
    }
}
