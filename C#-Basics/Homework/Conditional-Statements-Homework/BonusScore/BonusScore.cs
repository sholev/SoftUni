using System;

class BonusScore
{
    static void Main()
    {
        Console.WriteLine("Enter anything but an integer to exit.");
        Console.WriteLine(new String('-', 10));

        int score = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter number a = ");
                score = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return;
            }

            if (score >= 1 && score <= 3)
                Console.WriteLine(score * 10);

            else if (score >= 4 && score <= 6)
                Console.WriteLine(score * 100);

            else if (score >= 7 && score <= 9)
                Console.WriteLine(score * 1000);

            else
                Console.WriteLine("invalid score");

            Console.WriteLine(new String('-', 10));
        }
    }
}