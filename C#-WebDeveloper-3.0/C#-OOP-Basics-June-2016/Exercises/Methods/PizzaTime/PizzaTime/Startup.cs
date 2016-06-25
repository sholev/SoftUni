namespace PizzaTime
{
    using System;
    using System.Linq;
    using System.Reflection;

    class Startup
    {
        static void Main(string[] args)
        {
            MethodInfo[] methods = typeof(Pizza).GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
            if (!containsMethod)
            {
                throw new Exception();
            }

            var pizzas = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var output = Pizza.ParsePizza(pizzas);

            foreach (var entry in output)
            {
                Console.WriteLine($"{entry.Key} - {string.Join(", ", entry.Value)}");
            }
        }
    }
}
