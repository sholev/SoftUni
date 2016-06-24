namespace Google
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var personName = parameters[0];
                var commannd = parameters[1];

                if (!people.ContainsKey(personName))
                {
                    people.Add(personName, new Person(personName));
                }

                switch (commannd)
                {
                    case "company":
                        var companyName = parameters[2];
                        var companyDepartment = parameters[3];
                        var salary = decimal.Parse(parameters[4]);
                        people[personName].Company = new Company(companyName, companyDepartment, salary);
                        break;
                    case "car":
                        var carModel = parameters[2];
                        var carSpeed = parameters[3];
                        people[personName].Car = new Car(carModel, carSpeed);
                        break;
                    case "pokemon":
                        var pokemonName = parameters[2];
                        var pokemonType = parameters[3];
                        people[personName].Pokemon.Add(new Pokemon(pokemonName, pokemonType));
                        break;
                    case "parents":
                        var parentName = parameters[2];
                        var parentBirthdate = parameters[3];
                        people[personName].Parents.Add(new FamilyMember(parentName, parentBirthdate));
                        break;
                    case "children":
                        var childName = parameters[2];
                        var childBirthdate = parameters[3];
                        people[personName].Children.Add(new FamilyMember(childName, childBirthdate));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            var personToPrint = Console.ReadLine();
            Console.Write(people[personToPrint]);
        }
    }
}