using System;

class NineDigitMagicNumbers
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        string nineDigitStr;
        int temp = 0;
        int exist = 0;

        for (int i = 111; i <= 777; i++)
        {
            if (Not089(i) && Not089(i + diff) && Not089(i + 2 * diff) && (i + 2 * diff) <= 777)
            {
                nineDigitStr = "" + i + (i + diff) + (i + 2 * diff);

                for (int l = 0; l < nineDigitStr.Length; l++)
                    temp += (int)Char.GetNumericValue(nineDigitStr[l]);     // Convert the chars to 
                                                                            // ints and sum them up
                if (temp == sum)
                {
                    Console.WriteLine(nineDigitStr);
                    exist++;
                }

                temp = 0;      // Makeing sure I'm not adding to
            }                  // the sum of the previous iteration
        }

        if (exist == 0)
            Console.WriteLine("No");
    }

    private static bool Not089(int n)
    {
        string digits = Convert.ToString(n);

        for (int i = 0; i < digits.Length; i++)
            if (digits[i] < '1' || digits[i] > '7')
                return false;

        return true;
    }
}
