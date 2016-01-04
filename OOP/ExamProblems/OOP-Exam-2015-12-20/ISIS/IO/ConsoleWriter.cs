namespace ISIS.IO
{
    using System;

    using ISIS.Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void PrintOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}
