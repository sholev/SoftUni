namespace BasicDictionaryOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Phonebook
    {
        static void Main(string[] args)
        {
            var phonebook = new SortedDictionary<string, string>();
            var input = Console.ReadLine();
            var search = false;

            while (input != "stop")
            {
                if (input == "search")
                {
                    search = true;
                }

                if (input != "search" && !search)
                {
                    var parameters = input.Trim().Split('-');
                    phonebook[parameters[0]] = parameters[1];
                }
                else if (input != "search")
                {
                    if (input != "search" && phonebook.ContainsKey(input))
                    {
                        Console.WriteLine($"{input} -> {phonebook[input]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {input} does not exist.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
