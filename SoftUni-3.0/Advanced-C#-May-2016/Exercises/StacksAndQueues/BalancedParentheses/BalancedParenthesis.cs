namespace StacksAndQueues
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesis
    {
        public static void Main(string[] args)
        {
            var openingBrackets = new List<char> { '{', '(', '[' };
            var closingBrackets = new List<char> { '}', ')', ']' };
            var input = Console.ReadLine();

            var bracketStack = new Stack<char>();
            var positionsAreBalanced = true;
            foreach (char symbol in input)
            {
                if (openingBrackets.Contains(symbol))
                {
                    bracketStack.Push(symbol);
                }
                else if (bracketStack.Count != 0 && closingBrackets.Contains(symbol)
                         && bracketStack.Peek() == openingBrackets[closingBrackets.IndexOf(symbol)])
                {
                    bracketStack.Pop();
                }
                else
                {
                    positionsAreBalanced = false;
                    break;
                }
            }

            Console.WriteLine(positionsAreBalanced ? "YES" : "NO");
        }
    }
}
