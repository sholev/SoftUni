namespace StacksAndQueues
{
    using System;
    using System.Collections.Generic;

    class StackFibonacci
    {
        static void Main(string[] args)
        {
            var position = int.Parse(Console.ReadLine());
            var sequence = new Stack<long>();
            
            sequence.Push(1);
            sequence.Push(1);

            if (position == 2)
            {
                Console.WriteLine(1);
                return;
            }

            for (int i = 0; i < position - 1; i++)
            {
                var last = sequence.Pop();
                var previous = sequence.Pop();
                var current = previous + last;

                sequence.Push(previous);
                sequence.Push(last);
                sequence.Push(current);
            }

            sequence.Pop();
            Console.WriteLine(sequence.Peek());
        }
    }
}
