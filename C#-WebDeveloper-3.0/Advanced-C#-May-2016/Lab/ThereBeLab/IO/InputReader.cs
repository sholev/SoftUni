namespace ThereBeLab.IO
{
    using System;

    using ThereBeLab.Utils;

    public class InputReader
    {
        private const string EndCommand = "quit";

        public static void StartReadingCommands()
        {
            string input;
            while ((input = ReadCommand()) != EndCommand)
            {
                CommandInterpreter.InterpretCommand(input);
            }
        }

        private static string ReadCommand()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
            string input = Console.ReadLine()?.Trim();

            return input;
        }
    }
}
