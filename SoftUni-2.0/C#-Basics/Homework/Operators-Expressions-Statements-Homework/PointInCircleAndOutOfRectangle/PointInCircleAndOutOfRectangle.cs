using System;

class PointInCircleAndOutOfRectangle
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Int or Double to exit");
        double pointX = 0;
        double pointY = 0;

        double circleX = 1;
        double circleY = 1;
        double circleR = 1.5;

        double rektTop = 1;
        double rektLeft = -1;
        double rektWidth = 6;
        double rektHeight = 2;
          
        while (true)
        {
            try 
            {
                Console.Write("Enter X of the point: ");
                pointX = double.Parse(Console.ReadLine());
                Console.Write("Enter Y of the point: ");
                pointY = double.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            bool doesRectContain = isPointInRectangle(pointX, pointY, rektTop, rektLeft, rektWidth, rektHeight);

            //http://stackoverflow.com/questions/481144/equation-for-testing-if-a-point-is-inside-a-circle
            bool doesCircleContain = isPointInCircle(pointX, pointY, circleX, circleY, circleR);

            if (doesCircleContain && !doesRectContain)
                Console.WriteLine("Point ({0}, {1}) is inside K and outside of R.",
                    pointX, pointY);
            else
                Console.WriteLine("Point ({0}, {1}) does not meet the requirements.",
                    pointX, pointY);
            Console.WriteLine("Is in circle = {0}; Is in rectangle = {1};", doesCircleContain, doesRectContain);
            Console.WriteLine(new String('-', 10));
        }
    }

    private static bool isPointInRectangle(double pointX, double pointY, double rektTop, double rektLeft, double rektWidth, double rektHeight)
    {
        if (pointY <= rektTop && pointY >= rektTop - rektHeight &&
            pointX >= rektLeft && pointX <= rektLeft + rektWidth)
            return true;
        else
            return false;
    }

    private static bool isPointInCircle(double pointX, double pointY, double circleX, double circleY, double circleR)
    {
        if (Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2) <= Math.Pow(circleR, 2))
            return true;
        else
            return false;
    }
}