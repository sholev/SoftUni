using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PC_Catalog
{
    class Component
    {   // Fields.
        private string name;
        private string details;
        private double price;

        // Properties
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid component price. Make sure it is not negative.");
                }
                this.price = value;
            }
        }

        private string Details
        {
            get { return this.details; }
            set
            {
                if (value != null && value.Trim().Equals(String.Empty))
                {
                    throw new FormatException("Invalid details for component. Make sure the string isn't empty.");
                }
                this.details = value;
            }
        }

        private string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Invalid component name. Make sure it is not null.");
                }
                if (value.Trim().Equals(String.Empty))
                {
                    throw new FormatException("Invalid name. Make sure it is not empty.");
                }
                this.name = value;
            }
        }

        // Constructors
        public Component(string name, double price) : this(name, null, price)
        {
        }
        public Component(string name, string details, double price)
        {
            this.name = name;
            this.details = details;
            this.price = price;
        }

        // Methods
        public override string ToString()
        {
            return String.Format("{0}{1}{2}",
                this.name,
                this.details != null ? ": " + this.details: "",
                this.price > 0 ? "; " + this.price + "lv." : "" );
        }
    }
}
