namespace ExamProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CubicsRube
    {
        static void Main(string[] args)
        {
            var cubeSize = int.Parse(Console.ReadLine());
            var totalPositions = cubeSize * cubeSize * cubeSize;
            var thatFunkyDimension = new Dictionary<string, long>();

            string input;
            while ((input = Console.ReadLine()) != "Analyze")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var position = parameters[0] + parameters[1] + parameters[2];
                var coordinates = new[] { int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2]) };

                if (coordinates.All(c => c >= 0 && c < cubeSize))
                {
                    var amount = int.Parse(parameters[3]);
                    if (amount != 0)
                    {
                        thatFunkyDimension[position] = amount;
                    }
                }
            }

            long sum = 0;
            foreach (var position in thatFunkyDimension)
            {
                sum += position.Value;
            }
            
            Console.WriteLine(sum);
            Console.WriteLine(totalPositions - thatFunkyDimension.Count);
        }
    }
}
