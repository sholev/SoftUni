namespace CompanyHierarchy.Models.Person
{
    using System;

    using global::CompanyHierarchy.Interfaces;

    internal class Person : IPerson
    {
        private string name;
        private string surname;

        public uint Id { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name shold not be null or empty");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name should not be null or whitespace");
                }
                this.name = value;
            }
        }

        public string Surname
        {
            get
            {
                return this.surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name should not be null or empty");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name should not be null or whitespace");
                }
                this.surname = value;
            }
        }

        protected Person(uint id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()
        {
            return $"ID: {this.Id,-10} Name:{(this.Name + " " + this.Surname),-20}";
        }
    }
}
