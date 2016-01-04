namespace ISIS.IO
{
    using System;

    using ISIS.Interfaces;

    public class ConsoleReader : IInpputReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
