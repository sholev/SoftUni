using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Text;

class FallingRocks
{
    static void Main()
    {
        int numberOfRows = 19;
        int rowWidth = 40;
        int sleepTime = 150;
        string dwarfShape = "(0)";
        string rocks = "^@*&+%$#!.;";
        string rockHit = "H";
        string emptySpace = new string (' ', 250);

        List<string> availableSpace = new List<string>();

        for (int i = 0; i < numberOfRows; i++)
            availableSpace.Add(new string(' ', rowWidth));

        int dwarfPosition = rowWidth / 2 - 2;
        int numberOfHits = 0;
        int score = 0;

        do // http://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(sleepTime);

                score++;

                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (dwarfPosition > 0)
                                dwarfPosition--;
                            break;
       
                        case ConsoleKey.RightArrow:
                            if (dwarfPosition < rowWidth - 3)
                                dwarfPosition++;
                            break;

                        case ConsoleKey.Escape:
                            return;
                    }
                }

                availableSpace = GenerateFallingRocks(availableSpace, rowWidth, rocks + emptySpace);

                Console.Clear();
                Console.WriteLine("Score = {0}; Hits = {1}; Avoid the Rocks!", score - 10 * numberOfHits, numberOfHits);
                Console.WriteLine(new string('-', rowWidth));

                Console.Write(String.Join("\r\n", availableSpace.ToArray()));
                Console.Write("\r\n{0}", DrawDwarfAtPosition(dwarfPosition, dwarfShape, availableSpace, ref numberOfHits), rockHit);

                Console.WriteLine("\r\n{0}", new string('-', rowWidth));
                Console.WriteLine("Use <- amd -> to move. Press Esc for exit.");
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }

    private static string DrawDwarfAtPosition(int dwarfPosition, string dwarfShape, List<string> availableSpace, ref int hit)
    {
        string dwarfRow = availableSpace[availableSpace.Count - 1].ToString();
        if (dwarfRow[dwarfPosition] != ' ' || dwarfRow[dwarfPosition + 1] != ' ' || dwarfRow[dwarfPosition + 2] != ' ')
            hit = hit + 1;

        StringBuilder replacement = new StringBuilder(dwarfRow);
        replacement.Remove(dwarfPosition, dwarfShape.Length);
        replacement.Insert(dwarfPosition, dwarfShape);

        return replacement.ToString();
    }

    private static List<string> GenerateFallingRocks(List<string> availableSpace, int rowWidth, string rocks)
    {
        availableSpace.RemoveAt(availableSpace.Count - 1);
        availableSpace.Insert(0, GeneratedRow(rowWidth, rocks));

        return availableSpace;
    }

    private static string GeneratedRow(int rowWidth, string rocks) // http://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings-in-c
    {
        Random random = new Random();

        return new string(Enumerable.Repeat(rocks, rowWidth).Select(s => s[random.Next(s.Length)]).ToArray()); ;
    }
}
