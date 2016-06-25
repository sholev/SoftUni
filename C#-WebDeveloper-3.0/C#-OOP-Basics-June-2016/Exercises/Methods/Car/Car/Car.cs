namespace Car
{
    using System;

    public class Car
    {
        private double speed;

        private double fuel;

        private double fuelEconomy;

        private double travelDistance;

        public Car(double speed, double fuel, double fuelEconomy)
        {
            this.speed = speed;
            this.fuel = fuel;
            this.fuelEconomy = fuelEconomy / 100;

            this.travelDistance = 0;
        }

        public double Distance => this.travelDistance;

        public TimeSpan Time
        {
            get
            {
                var hours = this.travelDistance / this.speed;
                var ticks = (long)hours * 60 * 60 * 1000 * 10000;
                return new TimeSpan(ticks);
            }
        }

        public double Fuel => this.fuel;

        public void Travel(double distance)
        {
            var fuelNeeded = distance * this.fuelEconomy;
            if (this.fuel >= fuelNeeded)
            {
                this.fuel -= fuelNeeded;
                this.travelDistance += distance;
            }
            else
            {
                var possibleDistance = this.fuel / this.fuelEconomy;
                this.travelDistance += possibleDistance;
                this.fuel = 0;
            }
        }

        public void Refuel(double liters)
        {
            this.fuel += liters;
        }
    }
}