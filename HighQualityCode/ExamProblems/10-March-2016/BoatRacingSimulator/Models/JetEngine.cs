namespace BoatRacingSimulator.Models
{
    public sealed class JetEngine : BoatEngine
    {
        private const int Multiplier = 5;

        public JetEngine(string model, int horsepower, int displacement)
            : base(model, horsepower, displacement, Multiplier)
        {
        }
    }
}
