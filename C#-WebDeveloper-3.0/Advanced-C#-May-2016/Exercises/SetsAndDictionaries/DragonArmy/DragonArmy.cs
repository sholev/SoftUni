namespace SetsAndDictionariesOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DragonArmy
    {
        static void Main(string[] args)
        {
            var dragonData = new Dictionary<string, SortedDictionary<string, int[]>>();

            int numberOfDragons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] inParameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = inParameters[0];
                string name = inParameters[1];
                int damage = inParameters[2] == "null" ? 45 : int.Parse(inParameters[2]);
                int health = inParameters[3] == "null" ? 250 : int.Parse(inParameters[3]);
                int armor = inParameters[4] == "null" ? 10 : int.Parse(inParameters[4]);

                if (!dragonData.ContainsKey(type))
                {
                    dragonData[type] = new SortedDictionary<string, int[]>();
                }

                dragonData[type][name] = new[] { damage, health, armor };
            }

            foreach (var type in dragonData)
            {
                Console.WriteLine($"{type.Key}::({CalculateStats(type.Value)})");

                foreach (var dragon in type.Value)
                {
                    int[] stats = dragon.Value;
                    Console.WriteLine($"-{dragon.Key} -> damage: {stats[0]}, health: {stats[1]}, armor: {stats[2]}");
                }
            }
        }

        private static string CalculateStats(SortedDictionary<string, int[]> dragonsOfType)
        {
            var count = dragonsOfType.Count;
            var typeStats = new[] { 0.0, 0.0, 0.0 };

            foreach (var currentDragonStats in dragonsOfType.Select(dragon => dragon.Value))
            {
                for (int i = 0; i < currentDragonStats.Length; i++)
                {
                    typeStats[i] += currentDragonStats[i];
                }
            }

            return $"{typeStats[0] / count:f2}/{typeStats[1] / count:f2}/{typeStats[2] / count:f2}";
        }
    }
}
