namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            var inputParameters =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var rectangles = new Dictionary<string, Rectangle>();

            var numberOfRectangles = inputParameters[0];
            for (int i = 0; i < numberOfRectangles; i++)
            {
                var rectangleParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var id = rectangleParameters[0];
                var width = float.Parse(rectangleParameters[1]);
                var height = float.Parse(rectangleParameters[2]);
                var x = float.Parse(rectangleParameters[3]);
                var y = float.Parse(rectangleParameters[4]);

                rectangles[id] = new Rectangle(width, height, x, y);
            }

            var numberOfChecks = inputParameters[1];
            for (int i = 0; i < numberOfChecks; i++)
            {
                var checkParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstRectangle = rectangles[checkParameters[0]];
                var secondRectangle = rectangles[checkParameters[1]];

                Console.WriteLine($"{firstRectangle.Intersects(secondRectangle).ToString().ToLower()}");
            }
        }
    }
}