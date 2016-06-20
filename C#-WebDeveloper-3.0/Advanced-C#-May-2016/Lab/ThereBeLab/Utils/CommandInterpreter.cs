namespace ThereBeLab.Utils
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    using ThereBeLab.Data;
    using ThereBeLab.IO;
    using ThereBeLab.IO.File;
    using ThereBeLab.Messages;
    using ThereBeLab.Network;

    public class CommandInterpreter
    {
        public static void InterpretCommand(string input)
        {
            string[] parameters = Regex.Split(input, "\\s+");

            if (!ValidateParameterCount(parameters, 1)) return;

            string command = parameters[0];
            switch (command)
            {
                case Commands.OpenFile:
                    TryOpenFile(parameters);
                    break;
                case Commands.MakeDirectory:
                    TryCreateDirectory(parameters);
                    break;
                case Commands.ListDirectory:
                    TryTraverseFolders(parameters);
                    break;
                case Commands.CompareFiles:
                    TryCompareFiles(parameters);
                    break;
                case Commands.RelativePath:
                    TryChangePathRelarively(parameters);
                    break;
                case Commands.AbsolutePath:
                    TryChangePathAbsolute(parameters);
                    break;
                case Commands.ReadDatabase:
                    TryReadDatabaseFile(parameters);
                    break;
                case Commands.Help:
                    TryGetHelp();
                    break;
                case Commands.ShowData:
                    TryShowData(input, parameters);
                    break;
                case Commands.Filter:
                    TryFilterAndTake(input, parameters);
                    break;
                case Commands.Order:
                    TryOrderAndTake(input, parameters);
                    break;
                case Commands.Download:
                    TryDownloadFile(input, parameters);
                    break;
                case Commands.DownloadAsync:
                    TryDownloadFileAsync(input, parameters);
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private static void TryDownloadFile(string input, string[] parameters)
        {
            if (parameters.Length == 2)
            {
                var url = parameters[1];
                DownloadManager.Download(url);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryDownloadFileAsync(string input, string[] parameters)
        {
            if (parameters.Length == 2)
            {
                var url = parameters[1];
                DownloadManager.DownloadAsync(url);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryOrderAndTake(string input, string[] parameters)
        {
            if (parameters.Length == 5)
            {
                string course = parameters[1];
                string orderType = parameters[2].ToLower();
                string takeCommand = parameters[3].ToLower();
                string takeCount = parameters[4].ToLower();

                TryParseParametersForOrderANdTake(takeCommand, takeCount, course, orderType);
            }
        }

        private static void TryParseParametersForOrderANdTake(
            string takeCommand,
            string takeCount,
            string course,
            string orderType)
        {
            if (takeCommand == "take")
            {
                if (takeCount == "all")
                {
                    StudentsRepository.OrderAndTake(course, orderType);
                }
                else
                {
                    int count;
                    var parseSuccessful = int.TryParse(takeCount, out count);
                    if (parseSuccessful)
                    {
                        StudentsRepository.OrderAndTake(course, orderType, count);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidOrderQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidOrderCommand);
            }
        }

        private static void TryFilterAndTake(string input, string[] parameters)
        {
            if (parameters.Length == 5)
            {
                string course = parameters[1];
                string filter = parameters[2].ToLower();
                string takeCommand = parameters[3].ToLower();
                string takeCount = parameters[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeCount, course, filter);
            }
        }

        private static void TryParseParametersForFilterAndTake(
            string takeCommand,
            string takeCount,
            string course,
            string filter)
        {
            if (takeCommand == "take")
            {
                if (takeCount == "all")
                {
                    StudentsRepository.FilterAndTake(course, filter);
                }
                else
                {
                    int count;
                    var parseSuccessful = int.TryParse(takeCount, out count);
                    if (parseSuccessful)
                    {
                        StudentsRepository.FilterAndTake(course, filter, count);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryShowData(string input, string[] parameters)
        {
            if (parameters.Length == 2)
            {
                string course = parameters[1];
                StudentsRepository.GetAllStudentsFromCourse(course);
            }
            else if (parameters.Length == 3)
            {
                string course = parameters[1];
                string user = parameters[2];
                StudentsRepository.GetStudentScoresFromCourse(course, user);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
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
            OutputWriter.WriteMessageOnNewLine(
                $"|{"filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)",-98}|");
            OutputWriter.WriteMessageOnNewLine(
                $"|{"order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)",-98}|");
            OutputWriter.WriteMessageOnNewLine(
                $"|{"download file - download: path of file (saved in current directory)",-98}|");
            OutputWriter.WriteMessageOnNewLine(
                $"|{"download file asinchronously - downloadAsynch: path of file (save in the current directory)",-98}|");
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