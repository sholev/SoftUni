using System;

/* You can tell I got bored by drawing tables.
 * Also I suck at math, so I couldn't solve that
 * for the life of me. It's a copy from here: 
 * http://www.softwareandfinance.com/CSharp/Solve_Quadratic_Equation.html
 */

class QuadraticEquation
{
    static void Main()
    {
        double a = Double.Parse(Console.ReadLine());
        double b = Double.Parse(Console.ReadLine());
        double c = Double.Parse(Console.ReadLine());

        double sqrtpart = b * b - 4 * a * c;
        double x, x1, x2, img;
        if (sqrtpart > 0)
        {
            x1 = (-b - System.Math.Sqrt(sqrtpart)) / (2 * a);
            x2 = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
            Console.WriteLine("x1={0}; x2={1}", x1, x2);
        }
        else if (sqrtpart < 0)
        {
            sqrtpart = -sqrtpart;
            x = -b / (2 * a);
            img = System.Math.Sqrt(sqrtpart) / (2 * a);
            Console.WriteLine("no real roots");
        }
        else
        {
            x = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
            Console.WriteLine("x1=x2={0}", x);
        }
    }
}