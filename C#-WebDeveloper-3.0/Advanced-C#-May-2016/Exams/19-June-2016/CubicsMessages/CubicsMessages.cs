namespace ExamProblems
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class CubicsMessages
    {
        static void Main(string[] args)
        {
            var validMessages = new List<string[]>();

            string input;
            while ((input = Console.ReadLine()) != "Over!")
            {
                var validMessageLength = int.Parse(Console.ReadLine());
                var match = Regex.Match(
                    input,
                    $@"^(?<frontNum>\d+)(?<message>[a-zA-Z]{{{validMessageLength}}})(?<backNum>[^a-zA-Z]*\d*)$");
                if (match.Groups.Count > 2)
                {
                    var currentMessage = match.Groups["message"].Value;
                    var currentValidationNumber = match.Groups["frontNum"].Value;

                    foreach (char c in match.Groups["backNum"].Value)
                    {
                        if (char.IsDigit(c))
                        {
                            currentValidationNumber += c;
                        }
                    }

                    validMessages.Add(new[] { currentMessage, currentValidationNumber });
                }
            }

            foreach (var validMessage in validMessages)
            {
                var message = validMessage[0];
                var number = validMessage[1];

                StringBuilder output = new StringBuilder($"{message} == ");
                foreach (var c in number)
                {
                    var index = (int)char.GetNumericValue(c);

                    if (message.Length > index && index >= 0)
                    {
                        output.Append(message[index]);
                    }
                    else
                    {
                        output.Append(" ");
                    }
                }

                Console.WriteLine(output.ToString());
            }
        }
    }
}