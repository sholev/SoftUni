namespace SpeedRacing
{
    public class Car
    {
        private string Model { get; set; }

        private decimal FuelAmount { get; set; }

        private decimal FuelConsumptionPerKm { get; set; }

        private decimal DistanceTraveled { get; set; }

        public Car(string model, decimal fuelAmount, decimal fuelConsumptionPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.DistanceTraveled = 0;
        }

        public bool Drive(decimal distance)
        {
            var fuelRequired = distance * this.FuelConsumptionPerKm;
            if (fuelRequired <= this.FuelAmount)
            {
                this.FuelAmount -= fuelRequired;
                this.DistanceTraveled += distance;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.DistanceTraveled}";
        }
    }
}