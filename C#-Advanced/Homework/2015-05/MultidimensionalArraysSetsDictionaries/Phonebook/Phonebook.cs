using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main(string[] args)
    {
        SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();

        string input = "PersonName-PhoneNumber";
        string[] nameAndNumber = new string[2];
        bool search = false;

        Console.WriteLine("Enter \"search\" to toggle between input and search.");
        Console.WriteLine("Enter \"END\" to exit.");
        Console.WriteLine("Phone input format: \"Person Name-Phone Number\"");

        while (input != "END")
        {
            // Toggle between search and input.
            if (input == "search")
            {
                search = !search;
                input = "PersonName-PhoneNumber"; // Make sure we do not get infinite loop.
            }
            else
            {
                // If we are searching
                if (search)
                {
                    if (phonebook.ContainsKey(input)) // If name exists.
                    {
                        Console.WriteLine($"{input} -> {phonebook[input]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {input} does not exist.");
                    }
                }
                else // If we aren't searching, we are adding numbers.
                {
                    if (!phonebook.ContainsKey(input))
                    {
                        nameAndNumber = input.Split('-');
                        phonebook.Add(nameAndNumber[0], nameAndNumber[1]);
                    }
                }
            }

            input = Console.ReadLine();
        }
    }
}
