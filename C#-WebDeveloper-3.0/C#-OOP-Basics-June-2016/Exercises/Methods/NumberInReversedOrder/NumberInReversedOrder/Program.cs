namespace NumberInReversedOrder
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine();

            var wrappedNumber = new DecimalNumber(number);
            Console.WriteLine(wrappedNumber.GetNumberReversed());
        }
    }
}
