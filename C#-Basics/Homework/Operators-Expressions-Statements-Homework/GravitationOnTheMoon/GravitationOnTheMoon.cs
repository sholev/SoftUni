using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Double or Int to exit");
        double weight = 0;


        while (true)
        {
            Console.Write("Enter weight: ");
            try
            {
                weight = Double.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            Console.WriteLine("{0} would weigh {1} on the moon.", weight, weight * 0.17);
            Console.WriteLine(new string('-', 10));
        }
    }
}