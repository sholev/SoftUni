namespace AC_TestingSystem.Models
{
    using System.Text;

    using AC_TestingSystem.Interfaces;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, int mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; }

        public string Model { get; }

        public int Mark { get; }

        public override string ToString()
        {
            // PERFORMANCE: Possible performance problem: Using string concatenation instead of StringBuilder.
            StringBuilder output = new StringBuilder();
            string mark = string.Empty;

            switch (this.Mark)
            {
                case 0:
                    mark = "Failed";
                    break;
                case 1:
                    mark = "Passed";
                    break;
            }

            output.AppendLine("Report");
            output.AppendLine("====================");
            output.Append("Manufacturer: ");
            output.AppendLine(this.Manufacturer);
            output.Append("Model: ");
            output.AppendLine(this.Model);
            output.Append("Mark: ");
            output.AppendLine(mark);
            output.Append("====================");

            return output.ToString();
        }
    }
}
