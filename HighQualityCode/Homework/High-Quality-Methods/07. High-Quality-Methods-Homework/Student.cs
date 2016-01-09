namespace Methods
{
    using System;

    public class Student
    {
        public Student(string firstName, string lastName, DateTime birthDate, params string[] otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string[] OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.BirthDate < other.BirthDate;
        }
    }
}
