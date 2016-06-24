namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            var cars = new Dictionary<string, Car>();

            var carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = parameters[0];
                var fuelAmount = decimal.Parse(parameters[1]);
                var fuelConsumptionPerKm = decimal.Parse(parameters[2]);

                cars.Add(model, new Car(model, fuelAmount, fuelConsumptionPerKm));
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var model = parameters[1];
                var distance = long.Parse(parameters[2]);

                var driveSuccess = cars[model].Drive(distance);
                if (!driveSuccess)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in cars.Values)
            {
                Console.WriteLine(car);
            }
        }
    }
}
