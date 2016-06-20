namespace ThereBeLab.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ThereBeLab.IO;
    using ThereBeLab.Messages;

    public class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> users, string filter, int count)
        {
            switch (filter)
            {
                case "excellent":
                    FilterAndTake(users, mark => mark >= 5, count);
                    break;
                case "average":
                    FilterAndTake(users, mark => mark < 5 && mark >= 3.5, count);
                    break;
                case "poor":
                    FilterAndTake(users, mark => mark < 3.5, count);
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidStudentsFilter);
                    break;
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> users, Predicate<double> givenFilter, int count)
        {
            var filteredUsers = users.Where(pair => givenFilter(Average(pair.Value))).Take(count);

            foreach (var filteredUser in filteredUsers)
            {
                OutputWriter.WriteMessageOnNewLine("----------------------");
                OutputWriter.PrintStudent(filteredUser);
                OutputWriter.WriteMessageOnNewLine($"--- Averae score: " + Average(filteredUser.Value));
                OutputWriter.WriteMessageOnNewLine("----------------------");
            }
        }

        private static double Average(List<int> marks)
        {
            double average = marks.Average() / 100;
            double mark = average * 4 + 2;

            return mark;
        }
    }
}
