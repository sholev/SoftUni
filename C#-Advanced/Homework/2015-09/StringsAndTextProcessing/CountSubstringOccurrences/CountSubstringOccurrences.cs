using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountSubstringOccurrences
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();
        string substringToFind = Console.ReadLine();
        int index = 0;
        int occuranceCounter = 0;        

        while (input.IndexOf(substringToFind, index) != -1)
        {
            index = input.IndexOf(substringToFind, index) + 1;
            occuranceCounter++;
        }

        Console.WriteLine(occuranceCounter);
    }
}