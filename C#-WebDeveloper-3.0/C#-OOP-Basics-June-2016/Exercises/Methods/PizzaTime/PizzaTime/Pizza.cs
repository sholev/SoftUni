namespace PizzaTime
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Pizza
    {
        private readonly string name;

        private readonly int group;

        public Pizza(string name, int group)
        {
            this.name = name;
            this.group = group;
        }

        public override string ToString()
        {
            return $"{this.group} {this.name}";
        }

        public static SortedDictionary<int, List<string>> ParsePizza(params string[] input)
        {
            var result = new SortedDictionary<int, List<string>>();
            var pizzaRegex = new Regex(@"(?<group>\d+)(?<name>\w+)");
            foreach (string element in input)
            {
                var match = pizzaRegex.Match(element);
                var group = int.Parse(match.Groups["group"].Value);
                var name = match.Groups["name"].Value;

                if (!result.ContainsKey(group))
                {
                    result[group] = new List<string>();
                }

                result[group].Add(name);
            }

            return result;
        }
    }
}