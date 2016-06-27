namespace DrawingTool
{
    using System;

    public class CorDraw
    {
        Figure figure;

        public CorDraw(Figure figure)
        {
            this.figure = figure;
        }

        public void DrawFigure()
        {
            Console.WriteLine(this.figure.Draw());
        }
    }
}