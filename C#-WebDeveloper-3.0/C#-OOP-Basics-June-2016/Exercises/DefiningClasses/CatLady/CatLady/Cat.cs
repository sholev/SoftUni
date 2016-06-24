namespace CatLady
{
    public class Cat
    {
        public string Name { get; set; }

        public Cat(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
