using System;

    class SumOfElements
    {
        static void Main()
        {
            string sNumbers = Console.ReadLine();

            char[] separator = new char[1]; separator[0] = ' '; 
            string[] arrStrNums = sNumbers.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            long[] iNumbers = Array.ConvertAll(arrStrNums, long.Parse);

            long sum = 0;
            long diff = long.MaxValue;

            Array.ForEach(iNumbers, delegate(long i) { sum += i; });
            for (int i = 0; i < iNumbers.Length; i++)
            {
                if ((sum - (iNumbers[i] * 2)) == 0 )
                {
                    Console.WriteLine("Yes, sum={0}", sum - iNumbers[i]);
                    return;
                }
                diff = Math.Min(diff, sum - (iNumbers[i] * 2));
            }
            Console.WriteLine("No, diff={0}", Math.Abs(diff));
        }
    }
