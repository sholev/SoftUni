namespace Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GassPump
    {
        public long AmountOfGass;
        public long DistanceToNextPump;
        public long Index;

        public GassPump(long amountOfGass, long distanceToNextPump, long index)
        {
            this.AmountOfGass = amountOfGass;
            this.DistanceToNextPump = distanceToNextPump;
            this.Index = index;
        }
    }

    class TruckTour
    {
        static void Main(string[] args)
        {
            var totalPumps = long.Parse(Console.ReadLine());
            var pumps = new Queue<GassPump>();

            for (long position = 0; position < totalPumps; position++)
            {
                var parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse).ToArray();
                pumps.Enqueue(new GassPump(parameters[0], parameters[1], position));
            }

            bool journeyCompleted = false;
            while (pumps.Count >= 0)
            {
                GassPump currentPump = pumps.Dequeue();
                GassPump startingPump = currentPump;
                long gassInTank = currentPump.AmountOfGass;

                while (gassInTank >= currentPump.DistanceToNextPump)
                {
                    gassInTank -= currentPump.DistanceToNextPump;
                    currentPump = pumps.Dequeue();
                    if (currentPump == startingPump)
                    {
                        journeyCompleted = true;
                        break;
                    }
                    gassInTank += currentPump.AmountOfGass;
                }

                if (journeyCompleted)
                {
                    Console.WriteLine(startingPump.Index);
                    break;
                }
            }
        }
    }
}