using System;

class WorkHours
{
    static void Main()
    {
        int requiredHours = Int32.Parse(Console.ReadLine());
        int deadlineDays = Int32.Parse(Console.ReadLine());
        int productivity = Int32.Parse(Console.ReadLine());

        double difference = Math.Floor(((deadlineDays * 0.90) * 12) * (productivity / 100d)) - requiredHours;


        if (difference < 0)
            Console.WriteLine("No\r\n{0}", difference);
        else
            Console.WriteLine("Yes\r\n{0}", difference);
    }
}
