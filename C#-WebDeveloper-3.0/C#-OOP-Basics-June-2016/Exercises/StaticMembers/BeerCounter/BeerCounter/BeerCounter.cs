namespace BeerCounter
{
    public static class BeerCounter
    {
        public static int BeerInStockCount { get; set; }

        public static int BeersDrankCount { get; set; }

        public static void BuyBeer(int beerCount)
        {
            BeerInStockCount += beerCount;
        }

        public static void DrinkBeer(int beerCount)
        {
            BeerInStockCount -= beerCount;
            BeersDrankCount += beerCount;
        }

        public new static string ToString()
        {
            return $"{BeerInStockCount} {BeersDrankCount}";
        }
    }
}