namespace BasicDictionaryOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FixEmails
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, string>();
            var forbiddenMails = new[] { ".us", ".uk" };
            var input = Console.ReadLine();
            while (input != "stop")
            {
                var name = input;
                var email = Console.ReadLine();

                if (!forbiddenMails.Any(email.Contains))
                {
                    resources[name] = email;
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
