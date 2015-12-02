namespace Shapes.Classes
{
    using Interfaces;

    public abstract class BasicShape : IShape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}
