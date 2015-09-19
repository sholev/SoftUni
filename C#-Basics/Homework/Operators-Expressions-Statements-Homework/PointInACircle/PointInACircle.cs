using System;

class PointInACircle
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Int or Double to exit");
        double positionX = 0;
        double positionY = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter X of the point: ");
                positionX = Double.Parse(Console.ReadLine());
                Console.Write("Enter Y of the point: ");
                positionY = Double.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            //http://stackoverflow.com/questions/481144/equation-for-testing-if-a-point-is-inside-a-circle

            double circleX = 0;
            double circleY = 0;
            double circleR = 2;
                
            if (Math.Pow(positionX - circleX, 2) + Math.Pow(positionY - circleY, 2) <= Math.Pow(circleR, 2))
                Console.WriteLine("Point ({0}, {1}) is INSIDE of circle K([{2}, {3}], {4})",
                    positionX, positionY, circleX, circleY, circleR);
            else
                Console.WriteLine("Point ({0}, {1}) is OUTSIDE of circle K([{2}, {3}], {4})",
                    positionX, positionY, circleX, circleY, circleR);

            Console.WriteLine(new string ('-', 10));
        }
    }
}
