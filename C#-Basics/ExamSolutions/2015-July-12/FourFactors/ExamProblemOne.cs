using System;

namespace FourFactors
{
    class ExamProblemOne
    {
        static void Main(string[] args)
        {
            double d_FG = double.Parse(Console.ReadLine());
            double d_FGA = double.Parse(Console.ReadLine());
            double d_3P = double.Parse(Console.ReadLine());
            double d_TOV = double.Parse(Console.ReadLine());
            double d_ORB = double.Parse(Console.ReadLine());
            double d_OppDRB = double.Parse(Console.ReadLine());
            double d_FT = double.Parse(Console.ReadLine());
            double d_FTA = double.Parse(Console.ReadLine());

            double d_eFG_facResult = (d_FG + 0.5 * d_3P) / d_FGA;
            double d_TOV_facResult = d_TOV / (d_FGA + 0.44 * d_FTA + d_TOV);
            double d_ORB_facResult = d_ORB / (d_ORB + d_OppDRB);
            double d_FT_facResult = d_FT / d_FGA;

            Console.WriteLine("eFG% {0:F3}", d_eFG_facResult);
            Console.WriteLine("TOV% {0:F3}", d_TOV_facResult);
            Console.WriteLine("ORB% {0:F3}", d_ORB_facResult);
            Console.WriteLine("FT% {0:F3}", d_FT_facResult);
        }
    }
}
