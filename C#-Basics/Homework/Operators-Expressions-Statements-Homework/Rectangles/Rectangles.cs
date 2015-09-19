using System;

class Rectangles
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Int or Double to exit");
        double width = 0;
        double height = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter rectangle width: ");
                width = Double.Parse(Console.ReadLine());
                Console.Write("Enter rectangle height: ");
                height = Double.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }
            
            Console.WriteLine("For rectangle ({0},{1}), the perimeter is {2}, the area is {3}.",
                width, height, 2 * (width + height), width * height);
            Console.WriteLine(new string('-', 10));
        }
    }
}