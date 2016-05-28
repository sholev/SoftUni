using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PC_Catalog
{
    class Computer
    {
        // Fields
        private string name;
        private Component[] components;
        private double totalPrice = 0;

        public double TotalPrice
        {
            get { return this.totalPrice; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid price. Make sure it is not negative.");
                }
                this.totalPrice = value;
            }
        }

        // Properties
        public Component[] Components
        {
            get { return this.components; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    foreach (var component in value)
                    {
                        TotalPrice += component.Price;
                    }
                    this.components = value;
                }                
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Invalid computer name. Make sure it is not null.");
                }
                if (value.Trim().Equals(String.Empty))
                {
                    throw new FormatException("Invalid computer name. Make sure it is not empty.");
                }
                this.name = value;
            }
        }

        // Constructors

        public Computer(string name, params Component[] components) : this (name, 0, components)
        {
        }
        public Computer(string name, double initialPrice, params Component[] components)
        {
            this.Name = name;
            this.Components = components;
            this.TotalPrice += initialPrice;
        }

        // Methods
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string separator = new string('-', 50);

            output.AppendLine(this.name);
            output.AppendLine(separator);
            if (Components != null)
            {
                foreach (var component in Components)
                {
                    output.AppendLine(component.ToString());
                }
                output.AppendLine(separator);
            }           
            
            output.AppendLine(this.TotalPrice.ToString() + "lv. ");
            return output.ToString();
        }
    }
}
