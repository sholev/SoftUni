namespace CarSalesman
{
    using System.Text;

    public class Car
    {
        private const string DefaultValue = "n/a";

        private const string Indent = "  ";

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weight { get; set; }

        public string Color { get; set; }

        public Car(
            string model,
            Engine engine,
            string weight = DefaultValue,
            string color = DefaultValue)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine($"{this.Model}:");
            output.AppendLine($"{this.Engine}");
            output.AppendLine($"{Indent}Weight: {this.Weight}");
            output.Append($"{Indent}Color: {this.Color}");

            return output.ToString();
        }
    }
}
