namespace Google
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<FamilyMember> Parents { get; set; }

        public List<FamilyMember> Children { get; set; }

        public List<Pokemon> Pokemon { get; set; }

        public Person(string name)
        {
            this.Name = name;
            this.Parents = new List<FamilyMember>();
            this.Children = new List<FamilyMember>();
            this.Pokemon = new List<Pokemon>();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(this.Name);
            result.AppendLine("Company:");
            if (this.Company != null) result.AppendLine(this.Company.ToString());
            result.AppendLine("Car:");
            if (this.Car != null) result.AppendLine(this.Car.ToString());
            result.AppendLine("Pokemon:");
            this.Pokemon?.ForEach(p => result.AppendLine(p.ToString()));
            result.AppendLine("Parents:");
            this.Parents?.ForEach(p => result.AppendLine(p.ToString()));
            result.AppendLine("Children:");
            this.Children?.ForEach(p => result.AppendLine(p.ToString()));

            return result.ToString();
        }
    }
}
