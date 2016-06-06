namespace ManualStringProcessing
{
    using System;

    class MelrahShake
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            bool isShaking = true;
            while (pattern.Length != 0 && input.Length != 0 && isShaking)
            {
                int firstOccurrence = input.IndexOf(pattern, StringComparison.Ordinal);
                int lastOccurrence = input.LastIndexOf(pattern, StringComparison.Ordinal);

                if (firstOccurrence != -1 && lastOccurrence != -1 && firstOccurrence != lastOccurrence)
                {
                    input = input.Remove(lastOccurrence, pattern.Length);
                    input = input.Remove(firstOccurrence, pattern.Length);

                    pattern = pattern.Remove(pattern.Length / 2, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    isShaking = false;
                }
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(input);
        }
    }
}
