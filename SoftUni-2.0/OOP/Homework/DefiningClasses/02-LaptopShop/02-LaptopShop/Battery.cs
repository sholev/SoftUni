using System;

namespace _02_LaptopShop
{
    class Battery
    {
        // Fields
        private string type;
        private double? life;

        // Properties
        public string Type
        {
            get { return this.type; }
            set
            {
                if (value != null && value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid battery type. Make sure it is not empty.");
                }
                this.type = value;
            }
        }
        public double? Life
        {
            get { return this.life; }
            set
            {
                if (value != null && value < 0)
                {
                    throw new FormatException("The battery life has to be greater than zero.");
                }
                this.life = value;
            }
        }

        // Constructors
        public Battery() : this(null, null)
        {
        }
        public Battery(string name, double? batteryLife)
        {
            this.Type = name;
            this.Life = batteryLife;
        }

        // Methods
        public override string ToString()
        {
            return String.Format("{0}{1}",
               this.Type != null ? "Battery type: ".PadLeft(15) + this.Type + "\r\n": String.Empty,
               this.Life != null ? "Battery life: ".PadLeft(15) + this.Life + "\r\n" : String.Empty);
        }
    }
}
