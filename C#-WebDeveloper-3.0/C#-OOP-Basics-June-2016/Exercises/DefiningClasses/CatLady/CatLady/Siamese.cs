namespace CatLady
{
    public class Siamese : Cat
    {
        public double EarSize { get; set; }

        public Siamese(string name, double earSize)
            : base(name)
        {
            this.EarSize = earSize;
        }

        public override string ToString()
        {
            return $"Siamese {base.ToString()} {this.EarSize}";
        }
    }
}
