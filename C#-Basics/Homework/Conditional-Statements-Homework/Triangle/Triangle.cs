using System;

class Triangle
{
    static void Main()
    {
        double Ax = double.Parse(Console.ReadLine());
        double Ay = double.Parse(Console.ReadLine());
        double Bx = double.Parse(Console.ReadLine());
        double By = double.Parse(Console.ReadLine());
        double Cx = double.Parse(Console.ReadLine());
        double Cy = double.Parse(Console.ReadLine());

        double AB = Math.Sqrt(Math.Pow(Bx - Ax, 2) + Math.Pow(By - Ay, 2));
        double BC = Math.Sqrt(Math.Pow(Cx - Bx, 2) + Math.Pow(Cy - By, 2));
        double CA = Math.Sqrt(Math.Pow(Cx - Ax, 2) + Math.Pow(Cy - Ay, 2));

        if ((AB + BC > CA) && 
            (BC + CA > AB) && 
            (AB + CA > BC))
        {
            double halfPerimeter = (AB + BC + CA)/2;
            Console.WriteLine("Yes\r\n{0:F2}", Math.Sqrt(halfPerimeter * (halfPerimeter - AB) * (halfPerimeter - BC) * (halfPerimeter - CA)));
        }
        else
        {
            Console.WriteLine("No\r\n{0:F2}", AB);
        }
    }
}