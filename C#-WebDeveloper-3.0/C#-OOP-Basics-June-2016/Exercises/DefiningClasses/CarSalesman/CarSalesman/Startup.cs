namespace CarSalesman
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main(string[] args)
        {
            var engines = new Dictionary<string, Engine>();
            var engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var engineModel = parameters[0];
                var enginePower = parameters[1];

                string engineDisplacement = "n/a";
                string engineEfficiency = "n/a";
                if (parameters.Length >= 3)
                {
                    int displacement = -1;
                    if (int.TryParse(parameters[2], out displacement))
                    {
                        engineDisplacement = parameters[2];
                    }
                    else
                    {
                        engineEfficiency = parameters[2];
                    }

                    if (parameters.Length == 4)
                    {
                        engineEfficiency = displacement != -1 ? parameters[3] : parameters[2];
                    }
                }
                var engine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
                engines.Add(engineModel, engine);
            }

            var cars = new List<Car>();
            var carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var carModel = parameters[0];
                var carEngine = engines[parameters[1]];

                string carWeight = "n/a";
                string carColor = "n/a";
                if (parameters.Length >= 3)
                {
                    int weight = -1;
                    if (int.TryParse(parameters[2], out weight))
                    {
                        carWeight = parameters[2];
                    }
                    else
                    {
                        carColor = parameters[2];
                    }

                    if (parameters.Length == 4)
                    {
                        carColor = weight != -1 ? parameters[3] : parameters[2];
                    }
                }

                var car = new Car(carModel, carEngine, carWeight, carColor);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}