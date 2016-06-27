namespace DrawingTool
{
    using System;

    class Startup
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();
            CorDraw corDraw;

            switch (figure)
            {
                case "Square":
                    var size = int.Parse(Console.ReadLine());
                    var square = new Square(size);
                    corDraw = new CorDraw(square);
                    break;
                case "Rectangle":
                    var width = int.Parse(Console.ReadLine());
                    var height = int.Parse(Console.ReadLine());
                    var rectangle = new Rectangle(width, height);
                    corDraw = new CorDraw(rectangle);
                    break;
                default:
                    throw new ArgumentException();
            }

            corDraw.DrawFigure();
        }
    }
}
