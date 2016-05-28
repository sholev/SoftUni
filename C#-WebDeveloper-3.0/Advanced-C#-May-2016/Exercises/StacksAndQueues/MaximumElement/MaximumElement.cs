namespace Stacks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaximumElement
    {
        static void Main(string[] args)
        {
            var numberOfQueries = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxStack = new Stack<int>();
            maxStack.Push(int.MinValue);

            for (int i = 0; i < numberOfQueries; i++)
            {
                var parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var operation = parameters[0];

                switch (operation)
                {
                    case 1:
                        var number = parameters[1];
                        stack.Push(number);
                        if (stack.Peek() > maxStack.Peek())
                        {
                            maxStack.Push(stack.Peek());
                        }
                        break;
                    case 2:
                        var num = stack.Pop();
                        if (num == maxStack.Peek())
                        {
                            maxStack.Pop();
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxStack.Peek());
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
