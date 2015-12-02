namespace Shapes.Classes
{
    using System;

    public class Rhombus : BasicShape
    {
        public Rhombus(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateArea()
        {
            return (this.Height * this.Width) / 2;
        }

        public override double CalculatePerimeter()
        {
            double side = Math.Sqrt((this.Width * this.Width) + (this.Height * this.Height)) / 2;

            return side * 4;
        }
    }
}
