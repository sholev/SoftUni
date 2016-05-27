namespace StacksAndQueues
{
    using System;
    using System.Collections.Generic;

    public struct Plant
    {
        public int pesticide { get; }

        public int days { get; }

        public Plant(int pesticide, int days)
        {
            this.pesticide = pesticide;
            this.days = days;
        }
    }

    class PoisonousPlants
    {
        static void Main(string[] args)
        {
            var inputCount = int.Parse(Console.ReadLine());
            var inputPlants = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var plants = new Queue<int>();

            for (int i = 0; i < inputCount; i++)
            {
                var plant = int.Parse(inputPlants[i]);
                plants.Enqueue(plant);
            }

            var stack = new Stack<Plant>();
            var maxDaysAlive = 0;
            while (plants.Count > 0)
            {
                var pesticide = plants.Dequeue();
                var daysALive = 0;
                while (stack.Count > 0 && pesticide <= stack.Peek().pesticide)
                {
                    daysALive = Math.Max(daysALive, stack.Pop().days);
                }

                if (stack.Count == 0)
                {
                    daysALive = 0;
                }
                else
                {
                    daysALive++;
                }

                maxDaysAlive = Math.Max(maxDaysAlive, daysALive);

                stack.Push(new Plant(pesticide, daysALive));
            }

            Console.WriteLine(maxDaysAlive);
        }
    }
}
