using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladkosNotebook
{
    class ConsoleApplication
    {
        static void Main()
        {
            string input = string.Empty;
            var Notebook = new SortedDictionary<string, Dictionary<string, List<string>>>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputSplit = input.Split('|');
                string color = inputSplit[0];
                string winLossAgeName = inputSplit[1];
                string playerNameAgeOrOpponent = inputSplit[2];

                if (!Notebook.ContainsKey(color))
                {
                    Notebook[color] = new Dictionary<string, List<string>>();
                    Notebook[color]["age"] = new List<string>();
                    Notebook[color]["name"] = new List<string>();                    
                    Notebook[color]["opponents"] = new List<string>();
                    Notebook[color]["win"] = new List<string>();
                    Notebook[color]["win"].Add("1");
                    Notebook[color]["loss"] = new List<string>();
                    Notebook[color]["loss"].Add("1");

                }
                if ((inputSplit[1] == "name" || inputSplit[1] == "age"))
                {
                    Notebook[color][winLossAgeName].Add(playerNameAgeOrOpponent);
                }

                if ((inputSplit[1] == "win" || inputSplit[1] == "loss"))
                {
                    Notebook[color]["opponents"].Add(playerNameAgeOrOpponent);

                    if (inputSplit[1] == "win")
                    {
                        Notebook[color]["win"].Add("1");
                    }
                    if (inputSplit[1] == "loss")
                    {
                        Notebook[color]["loss"].Add("1");
                    }
                }                
            }
            

            double wins = 0;
            double losses = 0;
            int prints = 0;

            foreach (var colorPage in Notebook)
            {
                if (colorPage.Value["name"].Count < 1 ||            // If there is no name or age,
                    colorPage.Value["age"].Count < 1)               // 
                {                                                   //
                    continue;                                       // skip printing the page.
                }
                if (colorPage.Value["opponents"].Count < 1)
                {
                    colorPage.Value["opponents"].Add("(empty)");    // If no opponents, add (empty) to the list.
                }

                prints++;
                Console.WriteLine($"Color: {colorPage.Key}");

                foreach (var entry in colorPage.Value)
                {
                    if (entry.Key == "opponents")
                    {
                        entry.Value.Sort(StringComparer.Ordinal);
                        Console.WriteLine($"-{entry.Key}: {string.Join(", ", entry.Value)}");
                    }
                    else if (entry.Key != "win" && entry.Key != "loss")
                    {
                        Console.WriteLine($"-{entry.Key}: {entry.Value[0]}");
                    }
                    else if (entry.Key == "win")
                    {
                        wins = entry.Value.Select(int.Parse).Sum();
                    }
                    else if (entry.Key == "loss")
                    {
                        losses = entry.Value.Select(int.Parse).Sum();
                        Console.WriteLine($"-rank: {wins/losses:F}");
                    }
                }
            }

            if (prints == 0)
            {
                Console.WriteLine("No data recovered.");
            }

        }
    }
}
