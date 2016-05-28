using System;

class JoroTheBallChaser
{
    static void Main()
    {
        string leap = Console.ReadLine();
        double holidays = Double.Parse(Console.ReadLine());
        double homeWeekends = Double.Parse(Console.ReadLine());
        double addPlays = 0;

        if (leap == "t")
            addPlays += 3;

        double plays = (((52d - homeWeekends) * 2 / 3) + homeWeekends) + (holidays / 2) + addPlays;
        Console.WriteLine((int)plays);
    }
}
