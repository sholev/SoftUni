using System;
using System.Text;

class FourDigitNumber
{
    static void Main()
    {
        Console.WriteLine("Type in anything but Int to exit");
        int integer = 0;

        while (true)
        {
            try
            {
                Console.Write("Enter a four digit number: ");
                integer = Int32.Parse(Console.ReadLine());

                if (integer < 1000 || integer > 9999)
                    return;
            }
            catch
            {
                return;
            }

            int sum = SumOfDigits(integer);
            int reversed = ReverseInt(integer);

            string sInteger = integer.ToString();
            char[] lastInFront = { sInteger[3], sInteger[0], sInteger[1], sInteger[2] };
            char[] secondThirdSwap = { sInteger[0], sInteger[2], sInteger[1], sInteger[3] };

            Console.WriteLine("{0} - sum: {1}; \r\nreversed: {2}; \r\nlast in front: {3}; \r\nsecond and third swap: {4}.",
                integer, sum, reversed, new String(lastInFront), new String(secondThirdSwap));
            Console.WriteLine(new string('-', 10));
        }
    }

    private static int ReverseInt(int integer)
    {
        int result = 0;
        while (integer > 0)
        {
            result = result * 10 + integer % 10;
            integer /= 10;
        }
        return result;
    }

    private static int SumOfDigits(int integer)
    {
        int sum = 0;
        while (integer != 0)
        {
            sum += integer % 10;
            integer /= 10;
        }
        return sum;
    }
}

