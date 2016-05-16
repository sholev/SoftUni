using System;

namespace InheritenceAndAbstraction.Classes
{
    public abstract class Human
    {
        private string name;
        private string surname;

        public string Surname
        {
            get { return this.surname; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Surname should not be empty or null");
                }
                this.surname = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be empty or null");
                }
                this.name = value;
            }
        }

        public Human(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()
        {
            return String.Format($"Name: {(this.Name + " " + this.Surname),-20}");
        }
    }
}
