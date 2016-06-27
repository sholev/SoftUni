namespace ShapesVolume
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class TrianglePrism
    {
        public double BaseSide { get; }

        public double Height { get; }

        public double Length { get; }

        public TrianglePrism(double baseSide, double height, double length)
        {
            this.BaseSide = baseSide;
            this.Height = height;
            this.Length = length;
        }
    }

    public class Cube
    {
        public double SideLength { get; }

        public Cube(double sideLength)
        {
            this.SideLength = sideLength;
        }
    }

    public class Cylinder
    {
        public double Radius { get; }

        public double Height { get; }

        public Cylinder(double radius, double height)
        {
            this.Radius = radius;
            this.Height = height;
        }
    }

    public static class VolumeCalculator
    {
        public static double CalculateVolume(TrianglePrism prism)
        {
            var triangleArea = prism.BaseSide * prism.Length / 2;
            return triangleArea * prism.Height;
        }

        public static double CalculateVolume(Cylinder cylinder)
        {
            return Math.PI * (cylinder.Radius * cylinder.Radius) * cylinder.Height;
        }

        public static double CalculateVolume(Cube cube)
        {
            return cube.SideLength * cube.SideLength * cube.SideLength;
        }
    }

    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var shapeTypeName = parameters[0];
                var shapeParameters = parameters.Skip(1).Select(double.Parse).ToArray();
                var objectArray = new object[shapeParameters.Length];
                shapeParameters.CopyTo(objectArray, 0);

                var shapeClass = Assembly.GetExecutingAssembly().GetType($"ShapesVolume.{shapeTypeName}");
                var shape = Activator.CreateInstance(shapeClass, objectArray);

                var basicMathClass = Assembly.GetExecutingAssembly().GetType("ShapesVolume.VolumeCalculator");
                var targetMethod = basicMathClass.GetMethod("CalculateVolume", new Type[] { shape.GetType() });
                var output = targetMethod.Invoke(null, new[] { shape });
                Console.WriteLine($"{output:f3}");
            }
        }
    }
}