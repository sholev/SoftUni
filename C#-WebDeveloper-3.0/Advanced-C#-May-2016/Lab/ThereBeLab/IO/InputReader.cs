namespace ThereBeLab.IO
{
    using System;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    using ThereBeLab.Data;
    using ThereBeLab.Messages;

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

            if (ValidateParametersNumber(parameters, 1))
            {
                return;
            }

            string command = parameters[0];
            switch (command)
            {
                case "open":
                    string filename = parameters[1];
                    Process.Start($"{SessionData.CurrentPath}\\{filename}");
                    break;
                case "mkdir":
                    string directoryName = parameters[1];
                    IOManager.CreateDirectoryInCurrentFolder(directoryName);
                    break;
                case "ls":
                    if (parameters.Length == 1)
                    {
                        IOManager.TraverseDirectory(0);
                    }
                    else if (parameters.Length == 2)
                    {
                        int depth;
                        if (int.TryParse(parameters[1], out depth))
                        {
                            IOManager.TraverseDirectory(depth);
                        }
                        else
                        {
                            OutputWriter.DisplayException(ExceptionMessages.InvalidDepthNumber);
                        }
                    }
                    break;
                case "cmp":
                    if (parameters.Length == 3)
                    {
                        string firstPath = parameters[1];
                        string secondPath = parameters[2];

                        Tester.CompareContent(firstPath, secondPath);
                    }
                    break;
                case "cdRel":
                    string relativePath = parameters[1];
                    IOManager.ChangeCurrentDirectoryRelative(relativePath);
                    break;
                case "cdAbs":
                    string absolutePath = parameters[1];
                    IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
                    break;
                case "readDb":
                    string fileName = parameters[1];
                    StudentsRepository.InitializeData(fileName);
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
                    break;
            }
        }

        private static bool ValidateParametersNumber(string[] parameters, int length)
        {
            if (parameters.Length < length)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidParameters);
                return false;
            }

            return true;
        }

        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command \"{input}\" is invalid.");
        }

        private static string ReadCommand()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
            string input = Console.ReadLine()?.Trim();

            return input;
        }
    }
}
