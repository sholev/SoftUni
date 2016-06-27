namespace BeerCounter
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parameters =
                    input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var beersBought = parameters[0];
                var beersDrank = parameters[1];

                BeerCounter.BuyBeer(beersBought);
                BeerCounter.DrinkBeer(beersDrank);
            }

            Console.WriteLine(BeerCounter.ToString());
        }
    }
}
