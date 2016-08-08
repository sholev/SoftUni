namespace RecyclingStation.IO
{
    using System;

    using RecyclingStation.IO.Interfaces;

    public class ConsoleIO : IInputReader, IOutputWriter
    {
        public string ReadInput() => 
            Console.ReadLine();

        public void WriteOutput(string output) => 
            Console.WriteLine(output);
    }
}
