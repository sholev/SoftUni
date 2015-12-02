using System;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Classes.Person
{
    class Person : IPerson
    {
        private string name;
        private string surname;

        public uint ID { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name should not be null or empty");
                }
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name should not be null or whitespace");
                }
                this.name = value;
            }
        }

        public string Surname
        {
            get { return this.surname; }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name should not be null or empty");
                }
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name should not be null or whitespace");
                }
                this.surname = value;
            }
        }

        public Person(uint id, string name, string surname)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()
        {
            return $"ID: {ID,-10} Name:{(Name + " " + Surname),-20}";
        }
    }
}
