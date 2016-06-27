namespace Students
{
    using System;

    public class Student : IEquatable<Student>
    {
        public static int TotalStudentsInstantiated = 0;

        private readonly string name;

        public Student(string name)
        {
            this.name = name;
            TotalStudentsInstantiated++;
        }

        public bool Equals(Student other)
        {
            return this.name.Equals(other.name);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }
}