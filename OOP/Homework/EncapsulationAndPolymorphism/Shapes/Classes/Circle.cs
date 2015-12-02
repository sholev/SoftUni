namespace Shapes.Classes
{
    using System;
    using Interfaces;    

    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; set; }
        
        public double CalculateArea()
        {
            return Math.PI * (this.Radius * this.Radius);
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }
    }
}
