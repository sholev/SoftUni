namespace LastDigitName
{
    using System;

    class Startup
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine();
            var wrappedNumber = new Number(number);
            Console.WriteLine(wrappedNumber.GetLastDigit());
        }
    }
}
