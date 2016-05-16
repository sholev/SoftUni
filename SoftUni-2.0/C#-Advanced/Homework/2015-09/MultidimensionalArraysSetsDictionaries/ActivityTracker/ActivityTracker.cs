using System;
using System.Collections.Generic;
using System.Text;

class ActivityTracker
{
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        string[] inputLines = new string[lines];

        for (int i = 0; i < lines; i++)
        {
            inputLines[i] = Console.ReadLine();
        }

        SortedDictionary<int, SortedDictionary<string, decimal>> monthlyActivity =
            new SortedDictionary<int, SortedDictionary<string, decimal>>();

        int month = 0;
        string name = string.Empty;
        decimal distance = 0;

        foreach (string line in inputLines)
        {
            month = int.Parse(line.Split('/')[1]);
            name = line.Split(' ')[1];
            distance = decimal.Parse(line.Split(' ')[2]);

            if (!monthlyActivity.ContainsKey(month))
            {
                monthlyActivity[month] = new SortedDictionary<string, decimal>();
            }
            if (!monthlyActivity[month].ContainsKey(name))
            {
                monthlyActivity[month][name] = 0;
            }

            monthlyActivity[month][name] += distance;
        }

        StringBuilder temp = new StringBuilder();

        foreach (var entry in monthlyActivity)
        {
            
            Console.Write($"{entry.Key}: ");

            foreach (var person in entry.Value)
            {
                temp.AppendFormat($"{person.Key}({person.Value}), ");
            }
            Console.WriteLine(temp.ToString().TrimEnd(", ".ToCharArray()));
            temp.Clear();
        }
    }
}
