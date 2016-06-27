namespace Students
{
    using System.Collections.Generic;

    public class StudentGroup
    {
        private static readonly HashSet<Student> Students = new HashSet<Student>();

        public static int StudentsCount => Students.Count;

        public static void AddStudent(string name)
        {
            Students.Add(new Student(name));
        }
    }
}