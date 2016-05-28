using System;

namespace ConsoleApplication1
{
    class ExamTaskOne
    {
        static void Main(string[] args)
        {
            long weightLBS = long.Parse(Console.ReadLine());
            long heighInch = long.Parse(Console.ReadLine());
            long age = long.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            long workouts = long.Parse(Console.ReadLine());

            decimal heightCM = heighInch * 2.54m;
            decimal weightKG = weightLBS / 2.2m;

            decimal DCI = 0m;
            decimal BMR = 0m;

            if (gender == "m")
            {
                BMR = 66.5m + (13.75m * weightKG) + (5.003m * heightCM) - (6.755m * age);                
            }
            else if (gender == "f")
            {
                BMR = 655m + (9.563m * weightKG) + (1.850m * heightCM) - (4.676m * age);
            }

            if (workouts <= 0)
            {
                DCI = BMR * 1.2m;
            }
            else if (workouts >= 1 && workouts <= 3)
            {
                DCI = BMR * 1.375m;
            }
            else if (workouts >= 4 && workouts <= 6)
            {
                DCI = BMR * 1.55m;
            }
            else if (workouts >= 7 && workouts <= 9)
            {
                DCI = BMR * 1.725m;
            }
            else
            {
                DCI = BMR * 1.9m;
            }

            Console.WriteLine(Math.Floor(DCI));
        }
    }
}
