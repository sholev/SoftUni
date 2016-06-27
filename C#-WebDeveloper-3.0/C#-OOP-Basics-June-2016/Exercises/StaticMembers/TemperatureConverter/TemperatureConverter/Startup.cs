namespace TemperatureConverter
{
    using System;

    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var temperature = int.Parse(parameters[0]);
                var measuringScale = parameters[1];
                Console.WriteLine(Convert(temperature, measuringScale));
            }
        }

        private static string Convert(int temperature, string measuringScale)
        {
            var resultTemperature = 0.0;
            var resultMeasuringScale = string.Empty;
            switch (measuringScale)
            {
                case "Celsius":
                    resultTemperature = (temperature * 1.8) + 32;
                    resultMeasuringScale = "Fahrenheit";
                    break;
                case "Fahrenheit":
                    resultTemperature = (temperature - 32) / 1.8;
                    resultMeasuringScale = "Celsius";
                    break;
                default:
                    throw new ArgumentException();
            }

            return $"{resultTemperature:f2} {resultMeasuringScale}";
        }
    }
}
