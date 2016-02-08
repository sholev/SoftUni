namespace AC_TestingSystem.Models
{
    using System;
    using System.Text;

    using AC_TestingSystem.Data;

    public class AirConditioner
    {
        private string manufacturer;

        private string type;

        private string model;

        private int powerUsage;

        private int volumeCovered;

        private int electricityUsed;
        
        public AirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.VolumeCovered = volumeCoverage;
            this.type = "car";
        }
        
        public AirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;

            switch (energyEfficiencyRating)
            {
                case "A":
                    this.EnergyRating = 10;
                    break;
                case "B":
                    this.EnergyRating = 12;
                    break;
                case "C":
                    this.EnergyRating = 15;
                    break;
                case "D":
                    this.EnergyRating = 20;
                    break;
                case "E":
                    this.EnergyRating = 90;
                    break;
                default:
                    throw new ArgumentException(Constants.IncorrectRating);
            }

            this.PowerUsage = powerUsage;
            this.type = "stationary";
        }

        public AirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.VolumeCovered = volumeCoverage;
            this.ElectricityUsed = Convert.ToInt32(electricityUsed);
            this.type = "plane";
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Manufacturer", 4));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Model", 2));
                }

                this.model = value;
            }
        }
        
        public int EnergyRating { get; set; }

        private int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        private int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        private int PowerUsage
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public int Test()
        {
            int result = 0; 

            switch (this.type)
            {
                case "stationary":
                    if (this.powerUsage / 100 <= this.EnergyRating)
                    {
                        result = 1;
                    }

                    break;

                case "car":
                    double sqrtVolume = Math.Sqrt(this.volumeCovered);
                    if (sqrtVolume < 3)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = 2;
                    }

                    break;

                case "plane":
                    sqrtVolume = Math.Sqrt(this.volumeCovered);
                    if (this.ElectricityUsed / sqrtVolume < Constants.MinPlaneElectricity)
                    {
                        result = 1;
                    }

                    break;

                default:
                    result = 0;
                    break;
            }

            return result;
        }

        public override string ToString()
        {
            // PERFORMANCE: Possible performance problem: Using string concatenation instead of StringBuilder.
            StringBuilder output = new StringBuilder();

            output.AppendLine("Air Conditioner");
            output.AppendLine("====================");
            output.Append("Manufacturer: ");
            output.AppendLine(this.Manufacturer);
            output.Append("Model: ");
            output.AppendLine(this.Model);

            switch (this.type)
            {
                case "stationary":
                    string energy = "A";
                    switch (this.EnergyRating)
                    {
                        case 12:
                            energy = "B";
                            break;
                        case 15:
                            energy = "C";
                            break;
                        case 20:
                            energy = "D";
                            break;
                        case 90:
                            energy = "E";
                            break;
                    }

                    output.Append("Required energy efficiency rating: ");
                    output.AppendLine(energy);
                    output.Append("Power Usage(KW / h): ");
                    output.AppendLine(this.PowerUsage.ToString());
                    break;

                case "car":
                    output.Append("Volume Covered: ");
                    output.AppendLine(this.VolumeCovered.ToString());
                    break;

                default:
                    output.Append("Volume Covered: ");
                    output.AppendLine(this.VolumeCovered.ToString());
                    output.Append("Electricity Used: ");
                    output.AppendLine(this.ElectricityUsed.ToString());
                    break;
            }

            output.Append("====================");

            return output.ToString();
        }
    }
}
