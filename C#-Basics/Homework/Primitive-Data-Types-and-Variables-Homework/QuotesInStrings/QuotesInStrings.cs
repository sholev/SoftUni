using System;

class QuotesInStrings
{
    static void Main()
    {
        string first = "The \"use\" of quotations causes difficulties.";
        string second = "The \u0022use\u0022 of quotations causes difficulties.";

        Console.WriteLine("{0}\n{1}", first, second);
    }
}