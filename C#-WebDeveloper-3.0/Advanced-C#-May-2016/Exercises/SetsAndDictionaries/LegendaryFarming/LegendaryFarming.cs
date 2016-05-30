namespace BasicDictionaryOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            var items = new SortedDictionary<string, int>();
            var junk = new SortedDictionary<string, int>();

            items.Add("shards", 0);
            items.Add("fragments", 0);
            items.Add("motes", 0);

            while (true)
            {
                string[] input = Console.ReadLine()?
                    .Trim()
                    .ToLower()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < input?.Length; i += 2)
                {
                    string item = input[i + 1];
                    int quantity = int.Parse(input[i]);

                    switch (item)
                    {
                        case "shards":
                        case "fragments":
                        case "motes":
                            items[item] += quantity;
                            break;
                        default:
                            if (!junk.ContainsKey(item))
                            {
                                junk.Add(item, quantity);
                            }
                            else
                            {
                                junk[item] += quantity;
                            }
                            break;
                    }

                    if (IsFarmingDone(items))
                    {
                        PrintLeftovers(items, junk);
                        return;
                    }
                }
            }
        }

        private static void PrintLeftovers(SortedDictionary<string, int> items, SortedDictionary<string, int> junk)
        {
            foreach (var item in items.OrderByDescending(i => i.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var pieceOfJunk in junk)
            {
                Console.WriteLine($"{ pieceOfJunk.Key}: { pieceOfJunk.Value}");
            }
        }

        private static bool IsFarmingDone(SortedDictionary<string, int> items)
        {
            var successMessages = new Dictionary<string, string>
                                      {
                                          { "shards", "Shadowmourne obtained!" },
                                          { "fragments", "Valanyr obtained!" },
                                          { "motes", "Dragonwrath obtained!" }
                                      };

            foreach (var item in items.Where(item => item.Value >= 250))
            {
                items[item.Key] -= 250;
                Console.WriteLine(successMessages[item.Key]);

                return true;
            }

            return false;
        }
    }
}