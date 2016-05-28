using System;

class House
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        char house = '*';
        char emptySpace = '.';
        int index = 1; // This is used inside the roof.

        Console.WriteLine(new string(emptySpace, (numberOfLines - 1) / 2) + // Top of the house, or first row
            house +
            new string(emptySpace, (numberOfLines - 1) / 2));

        for (int i = 0; i < numberOfLines - 2; i++) // We skip two lines, the top and the bottom.
        {
            if (i < (numberOfLines - 2) / 2) // The roof.
            {
                Console.WriteLine(new string(emptySpace, (numberOfLines - 2 - index) / 2) +
                    house +
                    new string(emptySpace, index) +
                    house +
                    new string(emptySpace, (numberOfLines - 2 - index) / 2));
                index += 2;
            }

            else if (i == (numberOfLines - 2) / 2) // The center, or roof base.
            {
                index += 2;
                Console.WriteLine(new string(house, index));
            }

            else // The house
            {
                Console.WriteLine(new string(emptySpace, numberOfLines / 4) +
                    house +
                    new string(emptySpace, (numberOfLines - (2 + ((numberOfLines / 4) * 2)))) +
                    house +
                    new string(emptySpace, numberOfLines / 4));

            }
        }

        Console.WriteLine(new string(emptySpace, numberOfLines / 4) + //Base of the house, or last row.
            new string(house, (numberOfLines - (((numberOfLines / 4) * 2)))) +
            new string(emptySpace, numberOfLines / 4));
    }
}