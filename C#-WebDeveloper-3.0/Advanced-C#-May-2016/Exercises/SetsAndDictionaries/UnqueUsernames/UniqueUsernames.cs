namespace BasicSetOperations
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main(string[] args)
        {
            var numberOfUsernames = int.Parse(Console.ReadLine());
            var uniqueUsernames = new HashSet<string>();
            for (int i = 0; i < numberOfUsernames; i++)
            {
                uniqueUsernames.Add(Console.ReadLine());
            }

            foreach (string uniqueUsername in uniqueUsernames)
            {
                Console.WriteLine(uniqueUsername);
            }
        }
    }
}
