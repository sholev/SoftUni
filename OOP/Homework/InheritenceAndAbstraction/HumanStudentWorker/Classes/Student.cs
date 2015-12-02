using System;

namespace InheritenceAndAbstraction.Classes
{
    public class Student : Human
    {
        private string facultyNumber;

        public string FaculltyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Faculty number should not be empty or null");
                }
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Faculty number should be between 5-10 symbols");
                }
                facultyNumber = value;
            }
        }

        public Student(string name, string surname, string facultyNumber)
            : base(name, surname)
        {
            this.FaculltyNumber = facultyNumber;
        }

        public override string ToString()
        {
            return String.Format($"{base.ToString()} ID: {this.FaculltyNumber}");
        }
    }
}
