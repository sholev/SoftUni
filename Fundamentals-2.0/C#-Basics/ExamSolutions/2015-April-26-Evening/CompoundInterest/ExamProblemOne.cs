using System;

namespace CompoundInterest
{
    class ExamProblemOne
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            int term = int.Parse(Console.ReadLine());
            double interestBank = double.Parse(Console.ReadLine());
            double interestFriend = double.Parse(Console.ReadLine());

            double paybackBank = price * Math.Pow(1 + interestBank, term);
            double paybackFriend = price * ( 1 + interestFriend);

            if (paybackBank < paybackFriend)
            {
                Console.WriteLine("{0:F2} Bank", paybackBank);
            }
            else
            {
                Console.WriteLine("{0:F2} Friend", paybackFriend);
            }
        }
    }
}
