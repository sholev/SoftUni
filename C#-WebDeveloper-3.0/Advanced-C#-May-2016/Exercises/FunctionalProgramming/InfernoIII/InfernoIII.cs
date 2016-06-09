namespace FunctionalProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class InfernoIII
    {
        static void Main(string[] args)
        {
            var numbers =
                Regex.Split(Console.ReadLine(), "\\s+")
                    .Select((number, index) => new { Number = int.Parse(number), Index = index })
                    .ToDictionary(element => element.Index, element => element.Number);

            var activeFilters = new Dictionary<string, int[]>();
            string command;
            while ((command = Console.ReadLine()) != "Forge")
            {
                var parameters = Regex.Split(command, ";");

                var action = parameters[0];
                var filter = parameters[1].GetHashCode();
                var filterCondition = int.Parse(parameters[2]);

                var filterName = "" + filter + filterCondition;

                switch (action)
                {
                    case "Exclude":
                        if (!activeFilters.ContainsKey(filterName))
                        {
                            activeFilters.Add(filterName, new[] { filter, filterCondition });
                        }
                        break;
                    case "Reverse":
                        if (activeFilters.ContainsKey(filterName))
                        {
                            activeFilters.Remove(filterName);
                        }
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            Func<List<int>, int, bool> validator = (list, sum) => !list.Sum().Equals(sum);

            var sumLeft = "Sum Left".GetHashCode();
            var sumRight = "Sum Right".GetHashCode();
            var sumLeftRight = "Sum Left Right".GetHashCode();

            var filteredNumbers = new List<int>();
            foreach (var numberWithPosition in numbers)
            {
                var currentNumberIndex = numberWithPosition.Key;
                var dreddApproved = true;
                foreach (var activeFilter in activeFilters.Values)
                {
                    var left = 0;
                    var num = numbers[currentNumberIndex];
                    var right = 0;
                    if (activeFilter[0].Equals(sumLeft))
                    {
                        numbers.TryGetValue(currentNumberIndex - 1, out left);
                    }
                    else if (activeFilter[0].Equals(sumRight))
                    {
                        numbers.TryGetValue(currentNumberIndex + 1, out right);
                    }
                    else if (activeFilter[0].Equals(sumLeftRight))
                    {
                        numbers.TryGetValue(currentNumberIndex - 1, out left);
                        numbers.TryGetValue(currentNumberIndex + 1, out right);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    var selectedNumbers = new List<int> { left, num, right };
                    dreddApproved = validator(selectedNumbers, activeFilter[1]);
                    if (!dreddApproved)
                    {
                        break;
                    }
                }

                if (dreddApproved)
                {
                    filteredNumbers.Add(numberWithPosition.Value);
                }
            }

            Console.WriteLine(string.Join(" ", filteredNumbers));
        }
    }
}
