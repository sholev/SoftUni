namespace DrawingTool
{
    using System.Text;

    public class Square : Figure
    {
        private int size;

        public Square(int size)
        {
            this.size = size;
        }

        public override string Draw()
        {
            var output = new StringBuilder();
            output.AppendLine($"|{new string('-', this.size)}|");
            for (int i = 0; i < this.size - 2; i++)
            {
                output.AppendLine($"|{new string(' ', this.size)}|");
            }
            output.AppendLine($"|{new string('-', this.size)}|");

            return output.ToString();
        }
    }
}