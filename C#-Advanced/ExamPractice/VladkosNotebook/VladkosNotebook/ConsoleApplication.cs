using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladkosNotebook
{
    class ConsoleApplication
    {
        //class Page
        //{
        //    public string color;
        //    public string name;
        //    public string age;
        //    public List<string> opponents;
            
        //    public int wins;
        //    public int losses;

        //    public double GetRank()
        //    {
        //        return (wins + 1) / (losses + 1);
        //    }
        //}

        static void Main()
        {
            string input = string.Empty;
            var Notebook = new Dictionary<string, Dictionary<string, List<string>>>();
            //List<Page> pages = new List<Page>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputSplit = input.Split('|');
                string color = inputSplit[0];
                string winLossAgeName = inputSplit[1];
                string playerNameAgeOrOpponent = inputSplit[2];

                if (!Notebook.ContainsKey(color))
                {
                    Notebook[color] = new Dictionary<string, List<string>>();
                }
                if ((inputSplit[1] == "name" || inputSplit[1] == "age"))
                {
                    if (!Notebook[color].ContainsKey(winLossAgeName))
                    {
                        Notebook[color] = new Dictionary<string, List<string>>();
                        Notebook[color][winLossAgeName] = new List<string>();
                    }

                    Notebook[color][winLossAgeName].Add(playerNameAgeOrOpponent);
                }

                if ((inputSplit[1] == "win" || inputSplit[1] == "loss"))
                {
                    if (!Notebook[color].ContainsKey("opponents"))
                    {
                        Notebook[color] = new Dictionary<string, List<string>>();
                        Notebook[color]["opponents"] = new List<string>();
                        Notebook[color]["opponents"].Add(playerNameAgeOrOpponent);

                        Notebook[color] = new Dictionary<string, List<string>>();
                        Notebook[color]["win"] = new List<string>();
                        Notebook[color]["win"].Add("1");

                        Notebook[color] = new Dictionary<string, List<string>>();
                        Notebook[color]["loss"] = new List<string>();
                        Notebook[color]["loss"].Add("1");
                    }
                    if (inputSplit[1] == "win")
                    {
                        Notebook[color] = new Dictionary<string, List<string>>();
                        Notebook[color]["opponents"] = new List<string>();
                        Notebook[color]["opponents"].Add(playerNameAgeOrOpponent);
                        Notebook[color]["win"] = new List<string>();
                        Notebook[color]["win"].Add("1");
                    }
                    if (inputSplit[1] == "loss")
                    {
                        Notebook[color] = new Dictionary<string, List<string>>();
                        Notebook[color]["opponents"] = new List<string>();
                        Notebook[color]["opponents"].Add(playerNameAgeOrOpponent);
                        Notebook[color]["loss"] = new List<string>();
                        Notebook[color]["loss"].Add("1");
                    }
                }                
            }

            // Print the result here.

            foreach (var colorPage in Notebook)
            {
                Console.WriteLine($"Color: {colorPage.Key}");

                foreach (var entry in colorPage.Value)
                {
                    Console.WriteLine($"-{entry.Key}: Test");
                }
            }

        }
    }
}
