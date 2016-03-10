namespace BoatRacingSimulator.Models
{
    using System;

    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public sealed class SailBoat : IBoat
    {
        private string model;

        private int weight;
        
        private int sailEfficiency;

        public SailBoat(string model, int weight, int sailEfficiency)
        {
            this.SailEfficiency = sailEfficiency;
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

        public int SailEfficiency
        {
            get
            {
                return this.sailEfficiency;
            }

            private set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException(Constants.IncorrectSailEfficiencyMessage);
                }

                this.sailEfficiency = value;
            }
        }

        public double CalculateRaceSpeed(IRace race)
        {
            var speed = (race.WindSpeed * (this.SailEfficiency / 100d)) - this.Weight + (race.OceanCurrentSpeed / 2d);

            return speed;
        }
    }
}
