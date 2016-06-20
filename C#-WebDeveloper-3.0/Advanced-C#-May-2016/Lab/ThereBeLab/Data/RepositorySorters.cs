namespace ThereBeLab.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ThereBeLab.IO;
    using ThereBeLab.Messages;

    public class RepositorySorters
    {
        public static void OrderAndTake(Dictionary<string, List<int>> students, string comparison, int count)
        {
            var result = new Dictionary<string, List<int>>();
            switch (comparison)
            {
                case "ascending":
                    result = students.OrderBy(pair => pair.Value.Sum())
                        .Take(count)
                        .ToDictionary(pair => pair.Key, pair => pair.Value);
                    break;
                case "descending":
                    result =
                        students.OrderByDescending(pair => pair.Value.Sum())
                            .Take(count)
                            .ToDictionary(pair => pair.Key, pair => pair.Value);
                    break;
                default:
                    OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
                    break;
            }

            foreach (var student in result)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}