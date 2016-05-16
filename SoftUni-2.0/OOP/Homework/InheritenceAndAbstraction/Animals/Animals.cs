using System;
using System.Collections.Generic;
using System.Linq;
using Animals.Classes;
using System.IO;

namespace Animals
{
    class Animals
    {
        static void Main(string[] args)
        {
            var petNames = new List<string>();
            petNames = File.ReadAllLines(@"..\..\petNames.txt").ToList();
            Random RNG = new Random();
            var animals = new List<Animal>();

            foreach (var petPair in petNames)
            {
                string[] names = petPair.Split(" \t\r\n.()1234567890".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                switch (RNG.Next(1, 5))
                {
                    case 1:
                        animals.Add(new Dog(names[0], RNG.Next(1, 15), Gender.male));
                        animals.Add(new Dog(names[1], RNG.Next(1, 15), Gender.female));
                        break;

                    case 2:
                        animals.Add(new Cat(names[0], RNG.Next(1, 15), Gender.male));
                        animals.Add(new Cat(names[1], RNG.Next(1, 15), Gender.female));
                        break;

                    case 3:
                        animals.Add(new Frog(names[0], RNG.Next(1, 15), Gender.male));
                        animals.Add(new Frog(names[1], RNG.Next(1, 15), Gender.female));
                        break;

                    default:
                        animals.Add(new Tomcat(names[0], RNG.Next(1, 15)));
                        animals.Add(new Kitten(names[1], RNG.Next(1, 15)));
                        break;
                }
            }

            // TODO: handle the exception if there are no elements
            var avgDogAge = animals.Where(animal => animal is Dog).Select(animal => animal.Age).Average();
            var avgCatAge = animals.Where(animal => animal is Cat).Select(animal => animal.Age).Average();
            var avgFrogAge = animals.Where(animal => animal is Frog).Select(animal => animal.Age).Average();
            var avgTomcatAge = animals.Where(animal => animal is Tomcat).Select(animal => animal.Age).Average();
            var avgKittenAge = animals.Where(animal => animal is Kitten).Select(animal => animal.Age).Average();

            Console.WriteLine(
                "Average ages: Dogs - {0:f2}, Cats - {1:f2}, Frogs - {2:f2}, Tomcats - {3:f2}, Kittens - {4:f2}", 
                avgDogAge, avgCatAge, avgFrogAge, avgTomcatAge, avgKittenAge);
        }
    }
}
