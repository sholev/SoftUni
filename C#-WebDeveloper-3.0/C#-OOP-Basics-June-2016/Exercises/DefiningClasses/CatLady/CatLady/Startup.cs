namespace CatLady
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main(string[] args)
        {
            var cats = new Dictionary<string, Cat>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (parameters[0])
                {
                    case "Siamese":
                        var catName = parameters[1];
                        var catEarSize = double.Parse(parameters[2]);

                        cats.Add(catName, new Siamese(catName, catEarSize));
                        break;
                    case "Cymric":
                        catName = parameters[1];
                        var catFurLength = double.Parse(parameters[2]);

                        cats.Add(catName, new Cymric(catName, catFurLength));
                        break;
                    case "StreetExtraordinaire":
                        catName = parameters[1];
                        var catDecibelsOfMeows = double.Parse(parameters[2]);

                        cats.Add(catName, new StreetExtraordinaire(catName, catDecibelsOfMeows));
                        break;
                }
            }

            var outputCat = Console.ReadLine();
            Console.WriteLine(cats[outputCat]);
        }
    }
}
