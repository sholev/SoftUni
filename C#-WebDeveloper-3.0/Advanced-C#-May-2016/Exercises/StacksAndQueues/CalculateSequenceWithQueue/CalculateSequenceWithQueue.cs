namespace Queues
{
    using System;
    using System.Collections.Generic;

    class CalculateSequenceWithQueue
    {
        static void Main(string[] args)
        {
            var num = long.Parse(Console.ReadLine());
            var sequence = new Queue<long>();

            sequence.Enqueue(num);
            for (int i = 0; i < 50; i++)
            {
                sequence.Enqueue(sequence.Peek() + 1);
                sequence.Enqueue(2 * sequence.Peek() + 1);
                sequence.Enqueue(sequence.Peek() + 2);
                Console.Write($"{sequence.Dequeue()} ");
            }
        }
    }
}
