namespace CarSalesman
{
    using System.Text;

    public class Engine
    {
        private const string DefaultValue = "n/a";

        private const string Indent = "  ";

        public string Model { get; set; }

        public string Power { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }

        public Engine(
            string model,
            string power,
            string displacement = DefaultValue,
            string efficiency = DefaultValue)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine($"{Indent}{this.Model}:");
            output.AppendLine($"{Indent}{Indent}Power: {this.Power}");
            output.AppendLine($"{Indent}{Indent}Displacement: {this.Displacement}");
            output.Append($"{Indent}{Indent}Efficiency: {this.Efficiency}");

            return output.ToString();
        }
    }
}