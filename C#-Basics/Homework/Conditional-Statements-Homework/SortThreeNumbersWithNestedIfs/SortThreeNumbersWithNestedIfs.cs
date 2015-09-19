using System;

/* Annoying conditions... 
 * This would be so much more simple in an array. :D
 */

class SortThreeNumbersWithNestedIfs
{
    static void Main()
    {
        Console.WriteLine("Enter anything but a number to exit.");
        Console.WriteLine(new String('-', 10));
        double numA = 0.0;
        double numB = 0.0;
        double numC = 0.0;

        while (true)
        {
            try
            {
                Console.Write("a = ");
                numA = double.Parse(Console.ReadLine());

                Console.Write("b = ");
                numB = double.Parse(Console.ReadLine());

                Console.Write("c = ");
                numC = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return;
            }

            if (numA >= numB)
            {
                if (numB >= numC)
                    Console.WriteLine("{0}, {1}, {2}", numA, numB, numC);
                else if (numB <= numC)
                {
                    if (numC >= numA)
                        Console.WriteLine("{0}, {1}, {2}", numC, numA, numB);
                    else
                        Console.WriteLine("{0}, {1}, {2}", numA, numC, numB);
                }
            }

            else 
            {
                if (numA >= numC)
                    Console.WriteLine("{0}, {1}, {2}", numB, numA, numC);
                else if (numA <= numC)
                {
                    if (numB >= numC)
                        Console.WriteLine("{0}, {1}, {2}", numB, numC, numA);
                    else
                        Console.WriteLine("{0}, {1}, {2}", numC, numB, numA);
                }
            }

            Console.WriteLine(new String('-', 10));
        }
    }
}