namespace Google
{
    public class FamilyMember
    {
        public string Name { get; set; }

        public string Birthday { get; set; }

        public FamilyMember(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}