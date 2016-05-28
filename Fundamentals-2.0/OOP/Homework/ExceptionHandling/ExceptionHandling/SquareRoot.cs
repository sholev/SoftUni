using System;

class SquareRoot
{
    static void Main(string[] args)
    {
        int number = 0;
        try
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            double result = Math.Sqrt(number);
            if (result.Equals(double.NaN))
            {
                throw new FormatException();
            }
            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
