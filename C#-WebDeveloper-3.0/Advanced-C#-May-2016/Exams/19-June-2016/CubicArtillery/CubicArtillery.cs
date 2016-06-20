namespace ExamProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CubicArtillery
    {
        static void Main(string[] args)
        {
            var capacity = int.Parse(Console.ReadLine());
            var inputBunkers = new Queue<char>();
            var inputWeapons = new Queue<int>();

            string input;
            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string parameter in parameters)
                {
                    if (parameter.Length == 1 && char.IsLetter(parameter[0]))
                    {
                        inputBunkers.Enqueue(parameter[0]);
                    }
                    else
                    {
                        inputWeapons.Enqueue(int.Parse(parameter));
                    }
                }
            }

            var currentBunker = inputBunkers.Dequeue();
            var currentBunkerStorage = new Queue<int>();
            foreach (var weapon in inputWeapons)
            {
                currentBunkerStorage.Enqueue(weapon);

                var currentSum = currentBunkerStorage.Sum();
                if (currentSum >= capacity)
                {
                    if (currentSum > capacity)
                    {
                        while (currentBunkerStorage.Sum() > capacity)
                        {
                            currentBunkerStorage.Dequeue();
                        }
                    }

                    var currentContent = currentBunkerStorage.Count > 0 ? string.Join(", ", currentBunkerStorage) : "Empty";
                    var output = $"{currentBunker} -> {currentContent}";
                    Console.WriteLine(output);

                    currentBunker = inputBunkers.Dequeue();
                    currentBunkerStorage.Clear();
                }

                if (inputBunkers.Count == 0)
                {
                    break;
                }
            }

        }
    }
}