namespace BoatRacingSimulator.Models
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public sealed class Yacht : IBoat
    {
        private string model;

        private int weight;

        private int cargoWeight;

        public Yacht(string model, int weight, IBoatEngine engine, int cargoWeight)
        {
            this.CargoWeight = cargoWeight;
            this.Model = model;
            this.Weight = weight;
            this.Engine = engine;
        }

        public IBoatEngine Engine { get; private set; }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatModelLength);
                this.model = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Weight");
                this.weight = value;
            }
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public double CalculateRaceSpeed(IRace race)
        {
            var speed = this.Engine.Output - (this.Weight - this.CargoWeight) + (race.OceanCurrentSpeed / 2d);

            return speed;
        }
    }
}
