using System;

class PrimeNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Int to exit");
        int number = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter number to check: ");
                number = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }

            if (isPrime(number))
                Console.WriteLine("{0} is Prime.", number);
            else
                Console.WriteLine("{0} is NOT Prime.", number);

            Console.WriteLine(new string('-', 10));
        }
    }

    private static bool isPrime(int number) // http://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
    {
        if (number <= 1) return false;
        if (number == 2) return true;

        for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
        {
            if (number % i == 0) return false;
        }

        return true;    
    }
}