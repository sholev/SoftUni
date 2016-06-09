namespace FunctionalProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class PartyReservationModule
    {
        static void Main(string[] args)
        {
            var names = Regex.Split(Console.ReadLine(), "\\s+").ToList();
            var predicates = new Dictionary<string, Func<string, string, bool>>
            {
                { "Starts with", (name, substring) => name.StartsWith(substring) },
                { "Ends with", (name, substring) => name.EndsWith(substring) },
                { "Contains", (name, substring) => name.Contains(substring) },
                { "Length", (name, length) => name.Length.ToString().Equals(length) },
            };

            var activeFilters = new Dictionary<string, string[]>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                var parameters = Regex.Split(command, ";");

                var action = parameters[0];
                var filter = parameters[1];
                var filterCondition = parameters[2];

                var filterName = filter + filterCondition;

                switch (action)
                {
                    case "Add filter":
                        if (!activeFilters.ContainsKey(filterName))
                        {
                            activeFilters.Add(filterName, new[] { filter, filterCondition });
                        }
                        break;
                    case "Remove filter":
                        if (activeFilters.ContainsKey(filterName))
                        {
                            activeFilters.Remove(filterName);
                        }
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            var filteredNames = new List<string>();
            foreach (string name in names)
            {
                var dreddApproved = true;
                foreach (string[] value in activeFilters.Values)
                {
                    if (predicates[value[0]](name, value[1]))
                    {
                        dreddApproved = false;
                        break;
                    }
                }
                if (dreddApproved)
                {
                    filteredNames.Add(name);
                }
            }

            Console.WriteLine(string.Join(" ", filteredNames));
        }
    }
}
