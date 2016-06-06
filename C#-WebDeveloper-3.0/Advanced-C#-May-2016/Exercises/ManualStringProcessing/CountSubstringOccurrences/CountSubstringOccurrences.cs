namespace ManualStringProcessing
{
    using System;

    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string substringToFind = Console.ReadLine().ToLower();
            int index = 0;
            int occurrenceCounter = 0;

            while (input.IndexOf(substringToFind, index, StringComparison.Ordinal) != -1)
            {
                index = input.IndexOf(substringToFind, index, StringComparison.Ordinal) + 1;
                occurrenceCounter++;
            }

            Console.WriteLine(occurrenceCounter);
        }
    }
}
