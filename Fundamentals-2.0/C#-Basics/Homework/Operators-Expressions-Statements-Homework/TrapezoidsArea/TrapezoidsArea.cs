using System;

class TrapezoidsArea
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Int or Double to exit");
        double sideA = 0;
        double sideB = 0;
        double heigtH = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter side A: ");
                sideA = Double.Parse(Console.ReadLine());
                Console.Write("Enter side B: ");
                sideB = Double.Parse(Console.ReadLine());
                Console.Write("Enter height H: ");
                heigtH = Double.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            Console.WriteLine("The area is: {0}", ((sideA + sideB) / 2) * heigtH);
            Console.WriteLine(new String('-', 10));

        }
    }
}