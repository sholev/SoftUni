using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StringLenth
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder output = new StringBuilder();
        output.Append(input);

        if (output.Length < 20)
        {
            output.Append(new string('*', 20 - output.Length));
        }
        else if (output.Length > 20)
        {
            output.Remove(20, output.Length - 20);
        }

        Console.WriteLine(output);
    }
}
