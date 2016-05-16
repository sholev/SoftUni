namespace BoatRacingSimulator.Models
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public sealed class RowBoat : IBoat
    {
        private string model;

        private int weight;

        private int oars;

        public RowBoat(string model, int weight, int oars)
        {
            this.Oars = oars;
            this.Model = model;
            this.Weight = weight;
        }

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

        public int Oars
        {
            get
            {
                return this.oars;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Oars");
                this.oars = value;
            }
        }

        public double CalculateRaceSpeed(IRace race)
        {
            var speed = (this.Oars * 100) - this.Weight + race.OceanCurrentSpeed;

            return speed;
        }
    }
}
