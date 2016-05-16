using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class ExamTaskFour
    {
        static void Main(string[] args)
        {
            string[] rectInput = new string[2];
            
            rectInput = Console.ReadLine().Split(' ');
            double Ax = double.Parse(rectInput[0]);
            double Ay = double.Parse(rectInput[1]);
            rectInput = Console.ReadLine().Split(' ');
            double Bx = double.Parse(rectInput[0]);
            double By = double.Parse(rectInput[1]);
            rectInput = Console.ReadLine().Split(' ');
            double Cx = double.Parse(rectInput[0]);
            double Cy = double.Parse(rectInput[1]);
            rectInput = Console.ReadLine().Split(' ');
            double Dx = double.Parse(rectInput[0]);
            double Dy = double.Parse(rectInput[1]);

            double radius = double.Parse(Console.ReadLine());
            double step = double.Parse(Console.ReadLine());

            //double rektTop = Cy;
            //double rektLeft = Cx;
            //double rektHeight = Cy - By;
            //double rektWidth = Cx - Dx;

            //double startTop = rektTop;
            //double startLeft = rektLeft;

            int validPoints = 0;

            for (double i =  Ax + 0.2; i < Bx; i += step)
            {
                for (double j = By + 0.2; j < Cy; j += step)
                {
                    if (isPointInCircle(i, j, 0, 0, radius))
                    {
                        validPoints++;
                    }
                }
            }

            Console.WriteLine(validPoints);
        }

        //private static bool isPointInRectangle(double pointX, double pointY, double rektTop, double rektLeft, double rektWidth, double rektHeight)
        //{
        //    if (pointY <= rektTop && pointY >= rektTop - rektHeight &&
        //        pointX >= rektLeft && pointX <= rektLeft + rektWidth)
        //        return true;
        //    else
        //        return false;
        //}

        private static bool isPointInCircle(double pointX, double pointY, double circleX, double circleY, double circleR)
        {
            if (Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2) <= Math.Pow(circleR, 2))
                return true;
            else
                return false;
        }
    }
}
