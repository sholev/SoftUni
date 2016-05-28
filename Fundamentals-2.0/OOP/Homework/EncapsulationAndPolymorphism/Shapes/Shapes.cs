using System;
using System.Collections.Generic;

using Shapes.Classes;
using Shapes.Interfaces;

namespace Shapes
{
    class Shapes
    {
        static void Main(string[] args)
        {
            Random RNG = new Random();
            List<IShape> shapes = new List<IShape>();

            for (int i = 0; i < 10; i++)
            {
                switch(RNG.Next(0, 3))
                {
                    case 0:
                        shapes.Add(new Circle(RNG.Next() + RNG.NextDouble()));
                        break;
                    case 1:
                        shapes.Add(new Rhombus(RNG.Next() + RNG.NextDouble(), RNG.Next() + RNG.NextDouble()));
                        break;
                    case 2:
                        shapes.Add(new Rectangle(RNG.Next() + RNG.NextDouble(), RNG.Next() + RNG.NextDouble()));
                        break;
                }
            }

            foreach (var shape in shapes)
            {
                Console.WriteLine(
                    $"{shape.GetType().Name + ":",-10} Area: {shape.CalculateArea() + ";",-22} Perimeter: {shape.CalculatePerimeter()}");
            }
        }        
    }
}
