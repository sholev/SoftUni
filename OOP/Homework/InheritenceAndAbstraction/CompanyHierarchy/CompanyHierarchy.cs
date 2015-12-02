using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CompanyHierarchy.Interfaces;
using CompanyHierarchy.Classes.Person.Employee;
using CompanyHierarchy.Classes.Person.Employee.RegularEmployee;
using CompanyHierarchy.Classes.Project;
using CompanyHierarchy.Classes.Sale;

namespace CompanyHierarchy
{
    class CompanyHierarchy
    {
        static void Main(string[] args)
        {            
            var people = new List<IEmployee>();
            uint idCounter = 0;
            Random RNG = new Random();
            var names = File.ReadAllLines(@"..\..\namesPeople.txt").ToList();
            var projects = File.ReadAllLines(@"..\..\namesProjects.txt").ToList();

            int temp = RNG.Next(15, 25);
            for (int i = 0; i < temp; i++)
            {
                // get random name and remove it from the list
                string randomName = names[RNG.Next(0, names.Count)];
                string[] lineContent = randomName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                names.Remove(randomName);

                string name = lineContent[0];
                string surname = lineContent[1];
                
                switch(RNG.Next(0 , 2))
                {
                    case 0:
                        people.Add(new Developer(
                            ++idCounter,
                            name,
                            surname,
                            (Department)RNG.Next(0, 4),
                            (decimal)(RNG.Next(1000, 4000) + RNG.NextDouble()),
                            GenerateRandomProjects(ref RNG, projects).ToArray()));
                        break;

                    case 1:
                        people.Add(new SalesEmployee(
                            ++idCounter,
                            name,
                            surname,
                            (Department)RNG.Next(0, 4),
                            (decimal)(RNG.Next(1000, 4000) + RNG.NextDouble()),
                            GenerateRandomSales(ref RNG, projects).ToArray()));
                        break;

                    default:
                        break;
                }
            }

            temp = RNG.Next(1, 3);
            for (int i = 0; i < temp; i++)
            {
                string randomName = names[RNG.Next(0, names.Count)];
                string[] lineContent = randomName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                names.Remove(randomName);

                string name = lineContent[0];
                string surname = lineContent[1];

                people.Add(new Manager(
                           ++idCounter,
                           name,
                           surname,
                           (Department)RNG.Next(0, 4),
                           (decimal)(RNG.Next(1000, 4000) + RNG.NextDouble()),
                           people.Where(p => !(p is Manager))));
            }

            Console.SetWindowSize(120, 30);
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
            
        }

        private static List<Sale> GenerateRandomSales(ref Random RNG, List<string> saleNames)
        {
            // get random project and remove it from the list
            string saleName = saleNames[RNG.Next(0, saleNames.Count)];
            saleNames.Remove(saleName);

            var sales = new List<Sale>();
            for (int i = 0; i < RNG.Next(1, 6); i++)
            {
                sales.Add(new Sale(
                    saleName,
                    GetRandomDate(new DateTime(), DateTime.Now, ref RNG),
                    (decimal)(RNG.Next(1000, 10000) + RNG.NextDouble())));
            }

            return sales;
        }

        private static List<Project> GenerateRandomProjects(ref Random RNG, List<string> projectNames)
        {
            // get random project and remove it from the list
            string projectName = projectNames[RNG.Next(0, projectNames.Count)];
            projectNames.Remove(projectName);

            var projects = new List<Project>();
            for (int i = 0; i < RNG.Next(1, 6); i++)
            {
                projects.Add(new Project(
                    projectName,
                    GetRandomDate(new DateTime(), DateTime.Now, ref RNG),
                    (State)RNG.Next(0, 2)));
            }

            return projects;
        }

        private static DateTime GetRandomDate(DateTime from, DateTime to, ref Random RNG)
        {
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(RNG.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }
    }
}
