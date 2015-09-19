using System;

namespace FruitMarket
{
    class ExamTaskOne
    {
        static void Main(string[] args)
        {
            double quantity = 0;
            string fruit = string.Empty;
            int inputProducts = 3;
            double price = 0;            

            string weekDay = Console.ReadLine();

            for (int i = 0; i < inputProducts; i++)
            {
                quantity = double.Parse(Console.ReadLine());
                fruit = Console.ReadLine();

                price += quantity * GetFruitPrice(fruit, weekDay);
            }

            Console.WriteLine("{0:F2}", price);
            
        }

        private static double GetFruitPrice(string fruit, string weekDay)
        {
            double price = 0;

            switch (fruit.ToLower())
            {
                case "banana":
                    price = 1.80;
                    break;

                case "cucumber":
                    price = 2.75;
                    break;

                case "tomato":
                    price = 3.20;
                    break;

                case "orange":
                    price = 1.60;
                    break;

                case "apple":
                    price = 0.86;
                    break;

                default:
                    break;
            }

            switch (weekDay.ToLower())
            {
                case "tuesday":
                    if (fruit == "apple" || fruit == "banana" || fruit == "orange")
                    {
                        price *= 0.8;
                    }
                    break;

                case "wednesday":
                    if (fruit == "tomato" || fruit == "cucumber")
                    {
                        price *= 0.9;
                    }
                    break;

                case "thursday":
                    if (fruit == "banana")
                    {
                        price *= 0.7;
                    }
                    break;

                case "friday":
                    price *= 0.9;
                    break;

                case "sunday":
                    price *= 0.95;
                    break;

                default:

                    break;
            }

            return price;
        }
    }
}
