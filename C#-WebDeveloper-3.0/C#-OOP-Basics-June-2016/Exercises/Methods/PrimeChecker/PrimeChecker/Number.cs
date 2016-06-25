namespace PrimeChecker
{
    using System;

    public class Number
    {
        private long number;

        private bool isPrime;

        public Number(long number, bool isPrime = false)
        {
            this.number = number;
            this.isPrime = isPrime;
        }

        public Number GetNextValidPrime()
        {
            long next = this.number + 1;
            var nextIsPrime = CheckPrime(next);

            while (!nextIsPrime)
            {
                next++;
                nextIsPrime = CheckPrime(next);
            }

            return new Number(next, this.isPrime);
        }

        public static bool CheckPrime(long number)
        {
            double squaredNumber = Math.Sqrt(number);
            for (int divisor = 2; divisor <= squaredNumber; divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return $"{this.number}, {this.isPrime.ToString().ToLower()}";
        }
    }
}