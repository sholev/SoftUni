namespace BasicDictionaryOperations
{
    using System;
    using System.Collections.Generic;

    class AMinerTask
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, decimal>();
            string input = Console.ReadLine();
            while (input  != "stop")
            {
                var resource = input;
                var amount = decimal.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, amount);
                }
                else
                {
                    resources[resource] += amount;
                }

                input = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
