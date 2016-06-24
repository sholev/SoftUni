namespace CatLady
{
    public class Cymric : Cat
    {
        public double FurLength { get; set; }

        public Cymric(string name, double furLength)
            : base(name)
        {
            this.FurLength = furLength;
        }

        public override string ToString()
        {
            return $"Cymric {base.ToString()} {this.FurLength:f2}";
        }
    }
}
