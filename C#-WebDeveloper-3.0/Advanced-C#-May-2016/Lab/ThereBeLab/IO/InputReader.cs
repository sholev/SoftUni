namespace ThereBeLab.IO
{
    using System;
    using System.Text.RegularExpressions;

    public class InputReader
    {
        private const string EndCommand = "quit";

        public static void StartReadingCommands()
        {
            string input = ReadCommand();
            while (input != EndCommand)
            {
                input = ReadCommand();
            }
        }

        public static void InterpretCommand(string input)
        {
            string[] parameters = Regex.Split("\\s+", input);
            string command = parameters[0];

            switch (command)
            {
                case "open":
                    break;
                case "mkdir":
                    break;
                case "ls":
                    break;
                case "cmp":
                    break;
                case "cdRel":
                    break;
                case "cdAbs":
                    break;
                case "readDb":
                    break;
                case "help":
                    break;
                case "filter":
                    break;
                case "order":
                    break;
                case "decOrder":
                    break;
                case "download":
                    break;
                case "downloadAsync":
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
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
