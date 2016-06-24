namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var model = parameters[0];
                var engineSpeed = int.Parse(parameters[1]);
                var enginePower = int.Parse(parameters[2]);
                var cargoWeight = int.Parse(parameters[3]);
                var cargoType = parameters[4];

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(model, engine, cargo, new List<Tire>());

                for (int j = 5; j < 12; j += 2)
                {
                    var tirePressure = float.Parse(parameters[j]);
                    var tireAge = int.Parse(parameters[j + 1]);
                    var tire = new Tire(tireAge, tirePressure);
                    car.Tires.Add(tire);
                }

                cars.Add(car);
            }

            var outputFilter = Console.ReadLine();
            var output = new List<Car>();
            if (outputFilter == "fragile")
            {
                output =
                    cars.Where(c => c.Cargo.Type.Equals(outputFilter))
                        .Where(car => car.Tires.Any(t => t.Pressure < 1))
                        .ToList();
            }
            else if (outputFilter == "flamable")
            {
                output =
                    cars.Where(c => c.Cargo.Type.Equals(outputFilter))
                        .Where(car => car.Engine.Power > 250)
                        .ToList();
            }

            foreach (Car car in output)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}