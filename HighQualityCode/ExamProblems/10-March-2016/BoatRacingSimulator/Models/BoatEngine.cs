namespace BoatRacingSimulator.Models
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public class BoatEngine : IBoatEngine
    {
        private readonly int multiplier;

        private string model;

        private int horsepower;

        private int displacement;

        protected BoatEngine(string model, int horsepower, int displacement, int multiplier)
        {
            this.multiplier = multiplier;
            this.Model = model;
            this.Horsepower = horsepower;
            this.Displacement = displacement;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }

        public int Output
        {
            get
            {
                if (this.CachedOutput != 0)
                {
                    return this.CachedOutput;
                }

                this.CachedOutput = (this.Horsepower * this.multiplier) + this.Displacement;
                return this.CachedOutput;
            }
        }

        private int CachedOutput { get; set; }

        private int Horsepower
        {
            get
            {
                return this.horsepower;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Horsepower");
                this.horsepower = value;
            }
        }

        private int Displacement
        {
            get
            {
                return this.displacement;
            }

            set
            {
                Validator.ValidatePropertyValue(value, "Displacement");
                this.displacement = value;
            }
        }
    }
}
