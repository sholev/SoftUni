namespace FibonacciNumbers
{
    using System.Collections.Generic;
    using System.Linq;

    public class Fibonacci
    {
        private Dictionary<int, long> numbers;

        public Fibonacci(int endPosition)
        {
            this.numbers = new Dictionary<int, long>();

            if (this.numbers.Count >= 0)
            {
                this.numbers[0] = 0;
            }

            if (this.numbers.Count >= 1)
            {
                this.numbers[0] = 0;
                this.numbers[1] = 1;
            }

            this.PopulateFibonacciNumbers(endPosition, this.numbers);
        }

        public List<long> GetNumbersInRange(int startPosition, int endPosition)
        {
            return this.numbers.Values.Skip(startPosition).Take(endPosition - startPosition).ToList();
        }

        private long PopulateFibonacciNumbers(int position, Dictionary<int, long> storedPositions)
        {
            if (position == 0 || position == 1)
            {
                return storedPositions[position];
            }

            if (storedPositions.ContainsKey(position))
            {
                return storedPositions[position];
            }

            return
                storedPositions[position] =
                this.PopulateFibonacciNumbers(position - 1, storedPositions)
                + this.PopulateFibonacciNumbers(position - 2, storedPositions);
        }
    }
}