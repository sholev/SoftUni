using System;

/* Copy/paste from the first problem with 
 * modifications to work on the current problem.
 */

class FormattingNumbers
{
    static void Main()
    {
        double[] nums = new double[3];
        double temp = 0d;

        bool interrupt = false;

        object input = String.Empty;

        string binary = String.Empty;
        string row = new String('-', 72);
        string info = "Type \"exit\" to end the program.\n";
        string table = "\r\n| a      | b      | c      | result                                    |\r\n";
        string soFar = info + row + table + row + "\r\n"; 

        do
        {
            for (int i = 0; i < 3; i++)
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

                soFar += String.Format("| {0,-7}", input.ToString());

                if (Double.TryParse(input.ToString(), out temp))
                {
                    nums[i] = temp;
                }
                Console.Clear();

            }

            binary = Convert.ToString((int)nums[0], 2);
            soFar += String.Format("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|\n{4}\n",
                (int)nums[0], binary.PadLeft(10, '0'), nums[1], nums[2], row);

        } while (!interrupt);
    }
}