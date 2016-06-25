namespace Car
{
    using System;
    using System.Linq;

    class Startup
    {
        private static void Main(string[] args)
        {
            double[] carParameters =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

            var car = new Car(carParameters[0], carParameters[1], carParameters[2]);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input.Contains("Travel"))
                {
                    double distance = double.Parse(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    car.Travel(distance);
                }
                else if (input.Contains("Refuel"))
                {
                    double fuel = double.Parse(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    car.Refuel(fuel);
                }
                else if (input.Contains("Distance"))
                {
                    Console.WriteLine($"Total distance: {car.Distance:f1} kilometers");
                }
                else if (input.Contains("Time"))
                {
                    Console.WriteLine($"Total time: {car.Time.Hours} hours and {car.Time.Minutes} minutes");
                }
                else if (input.Contains("Fuel"))
                {
                    Console.WriteLine($"Fuel left: {car.Fuel:f1} liters");
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}