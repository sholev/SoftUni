namespace BasicSetOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SetsOfElements
    {
        public static void Main(string[] args)
        {
            var setSizes =
                Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < setSizes[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setSizes[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            var resultSet = firstSet.Intersect(secondSet);

            Console.WriteLine(string.Join(" ", resultSet));
        }
    }
}
