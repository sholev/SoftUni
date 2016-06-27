namespace DrawingTool
{
    using System.Text;

    public class Rectangle : Figure
    {
        private int width;

        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override string Draw()
        {
            var output = new StringBuilder();
            output.AppendLine($"|{new string('-', this.width)}|");
            for (int i = 0; i < this.height - 2; i++)
            {
                output.AppendLine($"|{new string(' ', this.width)}|");
            }
            output.AppendLine($"|{new string('-', this.width)}|");

            return output.ToString();
        }
    }
}