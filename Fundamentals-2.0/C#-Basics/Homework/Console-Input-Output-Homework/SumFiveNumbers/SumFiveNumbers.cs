using System;

// I'll probably forget all those things I've googled by tomorrow. :(

class SumFiveNumbers
{
    static void Main()
    {
        string sNumbers = Console.ReadLine();
        char[] separator = new char[1];
        separator[0] = ' ';
        string[] arrStrNums = sNumbers.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        double[] iNumbers = Array.ConvertAll(arrStrNums, double.Parse);
        double sum = 0;
        Array.ForEach(iNumbers, delegate(double i) { sum += i; });
        Console.WriteLine(sum);
    }
}