using System;

/* Copy/paste from the first problem with 
 * modifications to work on the current problem
 * 
 * There is a requirement to not use if(). I won't
 * use it for the comparison, just for the rest
 * where I copied stuff from the previous program. :D
 */

class NumberComparer
{
    static void Main()
    {
        double result = 0d;
        double temp = 0d;

        bool interrupt = false;

        object input = String.Empty;

        string row = new String('-', 37);
        string info = "Type \"exit\" to end the program.\n";
        string table = "\r\n| a         | b         | greater   |\r\n";
        string soFar = info + row + table + row + "\r\n";

        do
        {
            result = Double.MinValue; // If I reset to zero negative values do not work.

            for (int i = 0; i < 2; i++)
            {
                Console.Write(soFar + "| ");
                input = Console.ReadLine();

                if (input.ToString() == "exit")
                {
                    interrupt = true;
                    Console.Clear();
                    Console.Write(soFar);
                    return;
                }

                soFar += String.Format("| {0,-10}", input.ToString());

                if (Double.TryParse(input.ToString(), out temp))
                {
                    result = Math.Max(result, temp);
                }
                Console.Clear();

            }

            soFar += String.Format("| {0,-10}|\n{1}\n", result, row);

        } while (!interrupt);
    }
}