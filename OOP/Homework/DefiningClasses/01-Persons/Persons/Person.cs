using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Person
    {
        private string name;
        private string email;
        private int age;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Invalid name. Make sure it is not null.");
                }
                if (value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid name. Make sure it is not empty.");
                }
                this.name = value;
            }
        }
        public string Email
        {
            get { return this.email ?? "[unavailable]"; }
            set
            {
                if (value != null && !value.Contains("@"))
                {
                    throw new FormatException("Invalid email. Make sure it contains @.");
                }
                this.email = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Invalid age. It must be > 1 and < 100");
                }
                this.age = value;
            }
        }
        public Person(string name, int age) : this(name, age, null) { }
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public override string ToString()
        {
            return String.Format($"Name: {this.Name}, Age: {this.Age}, Email: {this.Email}");
        }
    }
}
