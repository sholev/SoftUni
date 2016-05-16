namespace BoatRacingSimulator.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public sealed class PowerBoat : IBoat
    {
        private string model;

        private int weight;

        public PowerBoat(string model, int weight, IList<IBoatEngine> engines)
        {
            this.Model = model;
            this.Weight = weight;
            this.Engines = engines;
        }

        public IList<IBoatEngine> Engines { get; private set; }

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

        public double CalculateRaceSpeed(IRace race)
        {
            var speed = this.Engines.Sum(x => x.Output) - this.Weight + (race.OceanCurrentSpeed / 5d);

            return speed;
        }
    }
}
