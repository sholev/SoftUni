namespace Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueuesOperations
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numberOfEnqueues = parameters[0];
            var numberOfDequeues = parameters[1];
            var numberToFind = parameters[2];

            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numberStack = new Queue<int>();

            for (int i = 0; i < numberOfEnqueues; i++)
            {
                numberStack.Enqueue(inputNumbers[i]);
            }

            for (int i = 0; i < numberOfDequeues; i++)
            {
                numberStack.Dequeue();
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
