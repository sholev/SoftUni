namespace ExamProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    enum Meteors
    {
        Green,

        Red,

        Black
    }

    class CubicAssault
    {
        static void Main(string[] args)
        {
            var regionsData = new Dictionary<string, Dictionary<Meteors, long>>();

            string input;
            while ((input = Console.ReadLine()) != "Count em all")
            {
                var parameters = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var region = parameters[0];
                var type = (Meteors)Enum.Parse(typeof(Meteors), parameters[1]);
                var amount = int.Parse(parameters[2]);

                if (!regionsData.ContainsKey(region))
                {
                    regionsData.Add(region, new Dictionary<Meteors, long>());

                    foreach (Meteors meteor in Enum.GetValues(typeof(Meteors)))
                    {
                        regionsData[region].Add(meteor, 0);
                    }
                }

                regionsData[region][type] += amount;

                foreach (Meteors meteor in Enum.GetValues(typeof(Meteors)))
                {
                    while (meteor != Meteors.Black && regionsData[region][meteor] >= 1000000)
                    {
                        regionsData[region][meteor] -= 1000000;
                        var nextType = NextMeteor(meteor);
                        regionsData[region][nextType] += 1;
                    }
                }
            }

            foreach (var region in
                regionsData.OrderByDescending(pair => pair.Value[Meteors.Black])
                    .ThenBy(pair => pair.Key.Length)
                    .ThenBy(pair => pair.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var meteor in
                    region.Value.OrderByDescending(meteor => meteor.Value)
                    .ThenBy(meteor => meteor.Key.ToString()))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }

        public static Meteors NextMeteor(Meteors meteor)
        {
            switch (meteor)
            {
                case Meteors.Green:
                    return Meteors.Red;
                case Meteors.Red:
                    return Meteors.Black;
                default:
                    throw new ArgumentOutOfRangeException(nameof(meteor), meteor, null);
            }
        }
    }
}