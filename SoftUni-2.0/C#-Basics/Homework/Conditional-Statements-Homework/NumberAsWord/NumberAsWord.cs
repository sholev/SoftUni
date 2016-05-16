using System;

class NumberAsWord
{
    static void Main()
    {
        int integer = 0;

        Console.WriteLine("Type in anything but Int to exit.");

        while (true)
        {
            try
            {
                Console.Write("Enter number: ");
                integer = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return;
            }
            // Sometimes it might result in double space between words - example: 100013.
            // An easy fix is if we search for "  " and replace with " ",
            Console.WriteLine(FirstLetterToUpper(NumberToWords(integer)).Replace("  ", " ")); 
            Console.WriteLine(new string('-', 10));
        }
    }

    // http://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-for-maximum-performance
    private static string FirstLetterToUpper(string str)
    {
        if (str == null)
            return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
    }

    // http://stackoverflow.com/questions/2729752/converting-numbers-in-to-words-c-sharp
    // I know it will be best if I make my own method for practice, but now that I've
    // seen this, I feel that no matter what I come up with it will be inferior. :)
    // Maybe I will come back to it and try to come up with something of my own.
    // If you're reading this, then I didn't come back before the submission of this homework. :D
    private static string NumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        if (number < 0)
            return "minus " + NumberToWords(Math.Abs(number));

        string words = "";

        if ((number / 1000000000) > 0) // A bit of an extension here to work with the whole range of int. 
        {                              // Not needed right now, but I might in the future.
            words += NumberToWords(number / 1000000000) + " billion ";
            number %= 1000000000;
        }

        if ((number / 1000000) > 0)
        {
            words += NumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToWords(number / 1000) + " thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10]; // Changed "-" to " " to meet the condition of the problem.
            }
        }

        return words;
    }
}