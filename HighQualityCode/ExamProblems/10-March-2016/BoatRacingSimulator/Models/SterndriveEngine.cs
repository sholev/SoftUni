namespace BoatRacingSimulator.Models
{
    public sealed class SterndriveEngine : BoatEngine
    {
        private const int Multiplier = 7;

        public SterndriveEngine(string model, int horsepower, int displacement)
            : base(model, horsepower, displacement, Multiplier)
        {
        }
    }
}