using System;

class TheExplorer
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        char diamond = '*';
        char emptySpace = '-';
        int index = 1; // This is used inside the diamond

        Console.WriteLine(new string(emptySpace, (numberOfLines - 1) / 2) +
            diamond +
            new string(emptySpace, (numberOfLines - 1) / 2));

        for (int i = 0; i < numberOfLines - 2; i++)
        {
            if (i < (numberOfLines - 2) / 2)
            {
                Console.WriteLine(new string(emptySpace, (numberOfLines - 2 - index) / 2) + 
                    diamond +
                    new string(emptySpace, index) +
                    diamond +
                    new string(emptySpace, (numberOfLines - 2 - index) / 2));
                index += 2;
            }

            else if (i == (numberOfLines - 2) / 2)
            {
                Console.WriteLine(diamond +
                    new string(emptySpace, index) +
                    diamond);
            }

            else
            {
                index -= 2;
                Console.WriteLine(new string(emptySpace, (numberOfLines - 2 - index) / 2) + 
                    diamond +
                    new string(emptySpace, index) +
                    diamond +
                    new string(emptySpace, (numberOfLines - 2 - index) / 2));

            }
        }

        Console.WriteLine(new string(emptySpace, (numberOfLines - 1) / 2) +
            diamond +
            new string(emptySpace, (numberOfLines - 1) / 2));
    }
}