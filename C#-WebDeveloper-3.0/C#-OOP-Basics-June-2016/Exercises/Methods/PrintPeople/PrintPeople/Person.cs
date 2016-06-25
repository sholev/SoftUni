namespace PrintPeople
{
    using System;

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Occupation { get; set; }

        public Person(string name, int age, string occupation)
        {
            this.Name = name;
            this.Age = age;
            this.Occupation = occupation;
        }

        public int CompareTo(Person other)
        {
            return this.Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return $"{this.Name} - age: {this.Age}, occupation: {this.Occupation}";
        }
    }
}