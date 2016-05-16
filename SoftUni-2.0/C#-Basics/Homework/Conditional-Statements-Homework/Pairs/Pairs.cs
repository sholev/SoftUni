using System;

class Pairs
{
    static void Main()
    {
        string[] inputSplit = Console.ReadLine().Split(' '); // Converting the single string input 
                                                             // into an array for convenient conversion.

        int[] pairSums = new int[inputSplit.Length / 2]; // This will contain the sum of each pair.

        int maxDiff = 0;
        bool sameValue = true;

        for (int i = 0; i < inputSplit.Length / 2; i++) // For every entry in pairSums we get the 
        {                                               // corresponding pair sum of inputSplit
            
            pairSums[i] = int.Parse(inputSplit[i+i]) + int.Parse(inputSplit[i+i+1]);
        }

        for (int i = 0; i < pairSums.Length - 1; i++) 
        {
            if (sameValue && (pairSums[i] != pairSums[i + 1])) // We check if the sums meet the requirements
                sameValue = false;

            if (maxDiff < Math.Abs((pairSums[i] - pairSums[i + 1])))
                maxDiff = Math.Abs((pairSums[i] - pairSums[i + 1])); // We get the biggest difference
        }

        if (sameValue)
            Console.WriteLine("Yes, value={0}", pairSums[0]);
        else
            Console.WriteLine("No, maxdiff={0}", maxDiff);
    }
}