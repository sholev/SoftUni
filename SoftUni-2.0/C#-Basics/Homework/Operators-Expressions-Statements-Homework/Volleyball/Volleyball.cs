using System;

class Volleyball
{
    static void Main()
    {
        string year = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometown = int.Parse(Console.ReadLine());

        double weekendPlays = hometown + ((48.0 - hometown) * 3.0 ) / 4.0;
        double holidayPlays = (holidays * 2.0) / 3;
        double totalPlays = year == "leap" ? (weekendPlays + holidayPlays) * 1.15 : weekendPlays + holidayPlays;
        
        Console.WriteLine(Math.Floor(totalPlays));
    }
}