namespace ThereBeLab.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    using ThereBeLab.IO;
    using ThereBeLab.IO.File;
    using ThereBeLab.Messages;

    public class StudentsRepository
    {
        private const string ValidationPattern =
            @"(?<course>[A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+(?<student>[A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(?<mark>\d+)";

        public static bool IsDataInitialized = false;

        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData(string fileName)
        {
            if (!IsDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine(InformationMessages.ReadingData);
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitialized);
            }
        }

        public static void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossible(courseName, username))
            {
                OutputWriter.PrintStudent(
                    new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (var student in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(student);
                }
            }
        }

        public static void FilterAndTake(string courseName, string filter, int? count = null)
        {
            if (count == null)
            {
                count = studentsByCourse[courseName].Count;
            }

            RepositoryFilters.FilterAndTake(studentsByCourse[courseName], filter, count.Value);
        }

        public static void OrderAndTake(string courseName, string comparison, int? count = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (count == null)
                {
                    count = studentsByCourse[courseName].Count;
                }

                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, count.Value);
            }
        }

        private static void ReadData(string fileName)
        {
            Regex validationRegex = new Regex(ValidationPattern);

            var path = $"{SessionData.CurrentPath}\\{fileName}";

            if (!File.Exists(path))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidFile);
                return;
            }

            var inputLines = File.ReadAllLines(path);
            foreach (string input in inputLines)
            {
                if (!string.IsNullOrEmpty(input) && validationRegex.IsMatch(input))
                {
                    Match currentMatch = validationRegex.Match(input);

                    string course = currentMatch.Groups["course"].Value;
                    string student = currentMatch.Groups["student"].Value;

                    int mark;
                    bool markParseSuccess = int.TryParse(currentMatch.Groups["mark"].Value, out mark);

                    if (markParseSuccess && mark >= 0 && mark <= 100)
                    {
                        if (!studentsByCourse.ContainsKey(course))
                        {
                            studentsByCourse[course] = new Dictionary<string, List<int>>();
                        }

                        if (!studentsByCourse[course].ContainsKey(student))
                        {
                            studentsByCourse[course][student] = new List<int>();
                        }

                        studentsByCourse[course][student].Add(mark);
                        OutputWriter.WriteMessageOnNewLine(InformationMessages.SuccessfullyReadEntry + input);
                    }
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidEntry + input);
                }
            }
            IsDataInitialized = true;
            Console.WriteLine(InformationMessages.DoneReading);
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (IsDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }

                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDatabase);
            }

            OutputWriter.DisplayException(ExceptionMessages.DataNotInitialized);
            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDatabase);
            return false;
        }
    }
}
