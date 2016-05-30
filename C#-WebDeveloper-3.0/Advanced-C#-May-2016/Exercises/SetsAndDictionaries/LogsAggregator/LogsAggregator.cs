namespace SetsAndDictionariesOperations
{
    using System;
    using System.Collections.Generic;

    class LogsAggregator
    {
        static void Main(string[] args)
        {
            var userDurations = new SortedDictionary<string, int>();
            var userIPs = new Dictionary<string, SortedSet<string>>();

            int inputLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputLines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ipAddress = parameters[0];
                string name = parameters[1];
                int duration = int.Parse(parameters[2]);

                if (!userDurations.ContainsKey(name))
                {
                    userDurations[name] = duration;
                    userIPs[name] = new SortedSet<string> { ipAddress };
                }
                else
                {
                    userDurations[name] += duration;
                    userIPs[name].Add(ipAddress);
                }
            }

            foreach (var user in userDurations)
            {
                string name = user.Key;
                int duration = user.Value;
                string ipAddresses = string.Join(", ", userIPs[name]);

                Console.WriteLine($"{name}: {duration} [{ipAddresses}]");
            }
        }
    }
}
