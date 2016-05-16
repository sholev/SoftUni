using System;
using System.Collections.Generic;
using System.Linq;

// I couldn't sove this with bitwise operations.
// This is why I'm using a char list. T_T

namespace BitRoller
{
    class FifthExamProblem
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int frozenPosition = int.Parse(Console.ReadLine());

            // We don't need to roll the bits more than 18 times.
            int rollTimes = int.Parse(Console.ReadLine()) % 18; 
            
            char[] bitArray = Convert.ToString(input, 2).ToCharArray();
            List<char> charList = new List<char>(bitArray);
            charList.Reverse();

            while (charList.Count <= 18) // Make sure the list contains 19 elements.
            {
                charList.Add('0'); 
            }

            char frozenBit = charList[frozenPosition];
            char temporary = '0';
            charList.RemoveAt(frozenPosition);

            for (int i = 0; i < rollTimes; i++)
            {
                temporary = charList.First();
                charList.RemoveAt(0);
                charList.Add(temporary);
            }

            charList.Insert(frozenPosition, frozenBit);

            charList.Reverse();
            string output = string.Join("", charList);
            Console.WriteLine(Convert.ToInt32(output, 2));
        }
    }
}
