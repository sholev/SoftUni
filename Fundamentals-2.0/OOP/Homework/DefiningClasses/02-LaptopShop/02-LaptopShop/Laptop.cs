using System;

namespace _02_LaptopShop
{
    class Laptop
    {
        // Fields
        private string model;
        private string manufacturer;
        private string cpu;
        private string ram;
        private string gpu;
        private string hdd;
        private string display;
        private Battery battery;
        private double price;

        // Properties
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The price has to be greater than zero.");
                }
                this.price = value;
            }
        }        
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }
        public string Display
        {
            get { return this.display; }
            set
            {
                if (value != null && value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid Screen string. Make sure it is not empty.");
                }
                this.display = value;
            }
        }        
        public string HDD
        {
            get { return this.hdd; }
            set
            {
                if (value != null && value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid HDD string. Make sure it is not empty.");
                }
                this.hdd = value;
            }
        }
        public string GPU
        {
            get { return this.gpu; }
            set
            {
                if (value != null && value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid GPU string. Make sure it is not empty.");
                }
                this.gpu = value;
            }
        }
        public string RAM
        {
            get { return this.ram; }
            set
            {
                if (value != null && value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid RAM string. Make sure it is no empty.");
                }
                this.ram = value;
            }
        }
        public string CPU
        {
            get { return this.cpu; }
            set
            {
                if (value != null && value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid CPU string. Make sure it is not empty.");
                }
                this.cpu = value;
            }
        }
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value != null && value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid Manufacturer string. Make sure it is not empty.");
                }
                this.manufacturer = value;
            }
        }
        public string Model
        {
            get { return this.model; }
            set
            {
                if (value != null && value.Trim() == String.Empty)
                {
                    throw new FormatException("Invalid Model string. Make sure it is not empty.");
                }
                this.model = value;
            }
        }

        // Constructors
        public Laptop(string model, double price) 
            : this(model, null, null, null, null, null, null, new Battery(), price)
        {
        }

        public Laptop(string model, string manufacturer, double price) 
            : this(model, manufacturer, null, null, null, null, null, new Battery(), price)
        {
        }

        public Laptop(string model, string manufacturer, string cpu, double price)
            : this(model, manufacturer, cpu, null, null, null, null, new Battery(), price)
        {
        }

        public Laptop(string model, string manufacturer, string cpu, string ram, double price) 
            : this(model, manufacturer, cpu, ram, null, null, null, new Battery(), price)
        {
        }

        public Laptop(string model, string manufacturer, string cpu, string ram, string gpu,
            double price) 
            : this(model, manufacturer, cpu, ram, gpu, null, null, new Battery(), price)
        {
        }

        public Laptop( string model, string manufacturer, string cpu, string ram, string gpu,
            string hdd, double price) 
            : this(model, manufacturer, cpu, ram, gpu, hdd, null, new Battery(), price)
        {
        }

        public Laptop(string model, string manufacturer, string cpu, string ram, string gpu,
            string hdd, string display, double price) 
            : this(model, manufacturer, cpu, ram, gpu, hdd, display, new Battery(), price)
        {
        }

        public Laptop(string model, string manufacturer, string cpu, string ram, string gpu,
            string hdd, string display, Battery battery, double price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.CPU = cpu;
            this.RAM = ram;
            this.GPU = gpu;
            this.HDD = hdd;
            this.Display = display;
            this.Battery = battery;
            this.Price = price;
        }

        // Methods
        public override string ToString()
        {
            string separator = new string('-', 50);
            string newline = "\r\n";

            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",                
                "Model: ".PadLeft(15) + this.Model + newline,
                separator + "\r\n",
                this.Manufacturer != null ? "Manufacturer: ".PadLeft(15) + this.Manufacturer + newline : String.Empty,
                this.CPU != null ? "CPU: ".PadLeft(15) + this.CPU + newline : String.Empty,
                this.RAM != null ? "RAM: ".PadLeft(15) + this.RAM + newline : String.Empty,
                this.GPU != null ? "GPU: ".PadLeft(15) + this.GPU + newline : String.Empty,
                this.HDD != null ? "HDD: ".PadLeft(15) + this.HDD + newline : String.Empty,
                this.Display != null ? "Display: ".PadLeft(15) + this.Display + newline : String.Empty,
                this.Battery.ToString(),
                separator + newline,
                "Price: ".PadLeft(15) + this.Price + " lv." + newline);
        }
    }
}
