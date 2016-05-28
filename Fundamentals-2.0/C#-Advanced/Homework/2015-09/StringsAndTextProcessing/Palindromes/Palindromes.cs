using System;
using System.Collections.Generic;
using System.Linq;

class Palindromes
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        // http://stackoverflow.com/questions/5808284/convert-a-generic-list-to-iset
        // Split input and save it in a SortedSed to remove duplicates.
        SortedSet<string> inputWords = new SortedSet<string>(input.Split(" ,.?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
        
        // Get every entry of InputWords where the entry is equal to its reverse.
        IEnumerable<string> palindromes = inputWords.Where(w => w.SequenceEqual(w.Reverse()));

        Console.WriteLine(string.Join(", ", palindromes));
    }
}