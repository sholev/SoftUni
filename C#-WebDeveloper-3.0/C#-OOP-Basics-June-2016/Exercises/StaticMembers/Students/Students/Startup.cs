namespace Students
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main(string[] args)
        {
            //Students();
            UniqueStudentNames();
        }

        private static void UniqueStudentNames()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                StudentGroup.AddStudent(input);
            }

            Console.WriteLine(StudentGroup.StudentsCount);
        }

        private static void Students()
        {
            var studentsList = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                studentsList.Add(new Student(input));
            }

            Console.WriteLine(Student.TotalStudentsInstantiated);
        }
    }
}
