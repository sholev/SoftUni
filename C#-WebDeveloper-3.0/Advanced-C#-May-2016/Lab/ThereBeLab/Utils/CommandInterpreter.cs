namespace ThereBeLab.Utils
{
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    using ThereBeLab.Data;
    using ThereBeLab.IO;
    using ThereBeLab.Messages;

    public class CommandInterpreter
    {
        public static void InterpretCommand(string input)
        {
            string[] parameters = Regex.Split(input, "\\s+");

            if (!ValidateParameterCount(parameters, 1)) return;

            string command = parameters[0];
            switch (command)
            {
                case "open":
                    TryOpenFile(parameters);
                    break;
                case "mkdir":
                    TryCreateDirectory(parameters);
                    break;
                case "ls":
                    TryTraverseFolders(parameters);
                    break;
                case "cmp":
                    TryCompareFiles(parameters);
                    break;
                case "cdRel":
                    TryChangePathRelarively(parameters);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(parameters);
                    break;
                case "readDb":
                    TryReadDatabaseFile(parameters);
                    break;
                case "help":
                    TryGetHelp();
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

        private static void TryGetHelp()
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine($"|{"make directory - mkdir: path ",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"traverse directory - ls: depth ",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"comparing files - cmp: path1 path2",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"change directory - changeDirREl:relative path",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"change directory - changeDir:absolute path",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"read students data base - readDb: path",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"download file - download: path of file (saved in current directory)",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"download file asinchronously - downloadAsynch: path of file (save in the current directory)",-98}|");
            OutputWriter.WriteMessageOnNewLine($"|{"get help – help",-98}|");
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private static void TryReadDatabaseFile(string[] parameters)
        {
            if (!ValidateParameterCount(parameters, 2)) return;

            string fileName = parameters[1];
            StudentsRepository.InitializeData(fileName);
        }

        private static void TryChangePathAbsolute(string[] parameters)
        {
            if (!ValidateParameterCount(parameters, 2)) return;

            string absolutePath = parameters[1];
            IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }

        private static void TryChangePathRelarively(string[] parameters)
        {
            if (!ValidateParameterCount(parameters, 2)) return;

            string relativePath = parameters[1];
            IOManager.ChangeCurrentDirectoryRelative(relativePath);
        }

        private static void TryCompareFiles(string[] parameters)
        {
            if (!ValidateParameterCount(parameters, 3)) return;

            string firstPath = parameters[1];
            string secondPath = parameters[2];

            Tester.CompareContent(firstPath, secondPath);
        }

        private static void TryTraverseFolders(string[] parameters)
        {
            if (ValidateParameterCount(parameters, 2, false))
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
            else if (ValidateParameterCount(parameters, 1))
            {
                IOManager.TraverseDirectory(0);
            }
        }

        private static void TryCreateDirectory(string[] parameters)
        {
            if (!ValidateParameterCount(parameters, 2)) return;

            string directoryName = parameters[1];
            IOManager.CreateDirectoryInCurrentFolder(directoryName);
        }

        private static void TryOpenFile(string[] parameters)
        {
            if (!ValidateParameterCount(parameters, 2)) return;

            string filename = parameters[1];
            Process.Start($"{SessionData.CurrentPath}\\{filename}");
        }

        private static bool ValidateParameterCount(string[] parameters, int length, bool showException = true)
        {
            if (parameters.Length < length)
            {
                if (showException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidParameters);
                }
                return false;
            }

            return true;
        }

        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command \"{input}\" is invalid.");
        }
    }
}