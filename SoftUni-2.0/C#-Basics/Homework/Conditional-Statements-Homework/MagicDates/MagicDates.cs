using System;

class MagicDates
{
    static void Main()
    {
        DateTime startYear = DateTime.ParseExact(Console.ReadLine(), "yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime endYear = DateTime.ParseExact(Console.ReadLine(), "yyyy", System.Globalization.CultureInfo.InvariantCulture);

        endYear = endYear.AddYears(1);
        DateTime temporaryYear = startYear;

        int magicWeight = int.Parse(Console.ReadLine());
        int matchCounter = 0;

        while (temporaryYear < endYear)
        {
            if (CalculateDateWeight(temporaryYear) == magicWeight)
            {
                Console.WriteLine(temporaryYear.ToString("dd-MM-yyyy"));
                matchCounter++;
            }

            temporaryYear = temporaryYear.AddDays(1);
        }

        if (matchCounter == 0)
            Console.WriteLine("No");
    }

    private static int CalculateDateWeight(DateTime date)
    {
        string sDigits = date.ToString("ddMMyyyy");
        int[] iDigits = new int[sDigits.Length];
        int weight = 0;

        for (int i = 0; i < sDigits.Length; i++)
            iDigits[i] = int.Parse(sDigits[i].ToString());

        for (int i = 0; i < sDigits.Length; i++)
            for (int l = 0; l < sDigits.Length; l++)
                if (i != l)
                    weight += iDigits[i] * iDigits[l];

        return weight / 2;
    }
}