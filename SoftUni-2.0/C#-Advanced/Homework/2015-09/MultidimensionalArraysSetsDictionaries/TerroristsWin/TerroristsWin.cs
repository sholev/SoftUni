using System;
using System.Collections.Generic;
using System.Linq;

class TerroristsWin
{
    static void Main()
    {
        string input = Console.ReadLine();
        string result = string.Empty;

        Dictionary<int, int> bombLocationsAndSize = new Dictionary<int, int>();
        Dictionary<int, int> bombImpactSize = new Dictionary<int, int>();

        findBombs(input, ref bombLocationsAndSize);
        calculateExplosionImpact(bombLocationsAndSize, input, ref bombImpactSize);
        result = detonateBombs(input, bombImpactSize);

        Console.WriteLine(result);
    }

    private static string detonateBombs(string input, Dictionary<int, int> bombImpactSize)
    {
        char[] result = input.ToCharArray();

        foreach (var explosion in bombImpactSize)
        {
            for (int i = explosion.Key; i <= explosion.Value; i++)
            {
                result[i] = '.';
            }
        }

        return new string(result);
    }

    private static void calculateExplosionImpact(Dictionary<int, int> bombLocationsAndSize, string input, ref Dictionary<int, int> bombImpactSize)
    {
        int power = 0;

        foreach (var location in bombLocationsAndSize)
        {
            // Get the characters between |...| and calculate the power.
            power = calculatePower(input.Skip(location.Key + 1).Take(location.Value - (location.Key + 1)));
            // Increase the impact size based on the bomb locations and power. Make sure it is not out of range.
            bombImpactSize.Add(Math.Max(0, location.Key - power), Math.Min(input.Length - 1, location.Value + power));
        }
    }

    private static int calculatePower(IEnumerable<char> enumerable)
    {
        int power = 0;

        foreach (var letter in enumerable)
        {
            power += letter;
        }

        return power % 10;
    }

    private static void findBombs(string text, ref Dictionary<int, int> bombLocationsAndSize)
    {
        int position = 0;
        int size = 0;

        // Looking for the start of the bomb, this will be the position.
        for (int bombStart = 0; bombStart < text.Length; bombStart++)
        {            
            if (text[bombStart].Equals('|'))
            {
                position = bombStart;
                // Looking for the end of the bomb, this will be the size.
                for (int bombEnd = bombStart + 1; bombEnd < text.Length; bombEnd++)
                {
                    if (text[bombEnd].Equals('|'))
                    {
                        size = bombEnd;

                        // Make sure the first loop continues after the bomb.
                        bombStart = bombEnd + 1; 

                        // Store the bomb location and size.
                        bombLocationsAndSize.Add(position, size);

                        // End the second loop when we find the end.
                        break; 
                    }
                }
            }            
        }
    }
}
