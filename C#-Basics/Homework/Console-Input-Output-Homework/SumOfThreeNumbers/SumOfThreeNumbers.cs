using System;

/* A bit more complex to make it pretty, but
 * still, it doesn't take into account wrong input.
 */

class SumOfThreeNumbers
{
    static void Main()
    {
        decimal sum = 0m;
        decimal temp = 0m;

        bool interrupt = false;

        object input = String.Empty;

        string row = new String('-', 37); //row row row your boat ♪♫♪
        string info = "Type \"exit\" to end the program.\n";
        string table = "\r\n| a      | b      | c      | sum    |\r\n";
        string soFar = info + row + table + row + "\r\n"; // In "soFar" I keep all the text printed so far,
                                                        // in order to avoind the new line from Console.ReadLine() 
        do { // A loop for the rows
            sum = 0m;
            
            for (int i = 0; i < 3; i++) // A loop for the three numbers to sum on each row
            {
                Console.Write(soFar + "| ");
                input = Console.ReadLine();

                if (input.ToString() == "exit")
                {
                    interrupt = true;
                    Console.Clear();        // Clean up and print
                    Console.Write(soFar);   // what we have so far
                    return;                 // before we end.
                }

                soFar += String.Format("| {0,-7}", input.ToString());

                if (Decimal.TryParse(input.ToString(), out temp)) 
                { 
                    sum += temp;
                }
                Console.Clear();
                
            } 

            soFar += String.Format("| {0,-7}|\n{1}\n", sum, row);

        } while (!interrupt);
    }
}