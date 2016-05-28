namespace Stacks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfPushes = parameters[0];
            var numberOfPops = parameters[1];
            var numberToFind = parameters[2];

            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numberStack = new Stack<int>();

            for (int i = 0; i < numberOfPushes; i++)
            {
                numberStack.Push(inputNumbers[i]);
            }

            for (int i = 0; i < numberOfPops; i++)
            {
                numberStack.Pop();
            }

            if (numberStack.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numberStack.Count > 0 ? numberStack.Min() : 0);
            }
        }
    }
}
