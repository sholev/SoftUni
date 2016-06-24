namespace CatLady
{
    public class StreetExtraordinaire : Cat
    {
        public double DecibelsOfMeows { get; set; }

        public StreetExtraordinaire(string name, double decibelsOfMeows)
            : base(name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public override string ToString()
        {
            return $"StreetExtraordinaire {base.ToString()} {this.DecibelsOfMeows}";
        }
    }
}
