namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using global::CompanyHierarchy.Enumerations;
    using global::CompanyHierarchy.Interfaces;
    using global::CompanyHierarchy.Models.Person.Employee.Manager;
    using global::CompanyHierarchy.Models.Person.Employee.RegularEmployee;
    using global::CompanyHierarchy.Models.Project;
    using global::CompanyHierarchy.Models.Sale;

    public static class CompanyHierarchy
    {
        public static void Main(string[] args)
        {            
            var people = new List<IEmployee>();
            var rng = new Random();

            uint idCounter = 0;

            List<string> names = File.ReadAllLines(@"..\..\namesPeople.txt").ToList();
            List<string> projects = File.ReadAllLines(@"..\..\namesProjects.txt").ToList();

            int employeesToGenerate = rng.Next(15, 25);
            for (int currentEmployee = 0; currentEmployee < employeesToGenerate; currentEmployee++)
            {
                string name;
                string surname;
                RandomName(names, rng, out name, out surname);

                Department randomDepartment = (Department)rng.Next(0, 4);
                decimal randomSalary = (decimal)(rng.Next(1000, 4000) + rng.NextDouble());

                int randomNumber = rng.Next(0, 13);
                if (randomNumber % 2 == 0)
                {
                    IProject[] randomProjects = GenerateRandomProjects(rng, projects);

                    people.Add(new Developer(++idCounter, name, surname, randomDepartment, randomSalary, randomProjects));
                }
                else
                {
                    ISale[] randomSales = GenerateRandomSales(rng, projects);

                    people.Add(new SalesEmployee(++idCounter, name, surname, randomDepartment, randomSalary, randomSales));
                }

                if (currentEmployee == employeesToGenerate - 1)
                {
                    foreach (Department department in Enum.GetValues(typeof(Department)).Cast<Department>())
                    {
                        RandomName(names, rng, out name, out surname);

                        List<IEmployee> employesInDepartment = people
                            .Where(person => !(person is Manager))
                            .Where(person => person.Department == department)
                            .ToList();

                        decimal managerSalary = (employesInDepartment.Count + 1) * randomSalary;

                        people.Add(new Manager(++idCounter, name, surname, department, managerSalary, employesInDepartment));
                    }
                }
            }

            // Making sure the output fits appropriately in the console window.
            Console.SetWindowSize(120, 30);
            foreach (IEmployee person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void RandomName(List<string> names, Random rng, out string name, out string surname)
        {
            string randomName = names[rng.Next(0, names.Count)];
            string[] lineContent = randomName.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            names.Remove(randomName);

            name = lineContent[0];
            surname = lineContent[1];
        }

        // TODO: Figure out how to combine GenerateRandomSales and GenerateRandomProjects in a single method.
        private static Sale[] GenerateRandomSales(Random rng, IList<string> saleNames)
        {
            // get random sale and remove it from the list
            string saleName = saleNames[rng.Next(0, saleNames.Count)];
            saleNames.Remove(saleName);

            var sales = new List<Sale>();
            for (int i = 0; i < rng.Next(1, 6); i++)
            {
                DateTime randomDate = GetRandomDate(new DateTime(), DateTime.Now, rng);
                decimal randomPrice = (decimal)(rng.Next(1000, 10000) + rng.NextDouble());

                sales.Add(new Sale(saleName, randomDate, randomPrice));
            }

            return sales.ToArray();
        }

        private static Project[] GenerateRandomProjects(Random rng, IList<string> projectNames)
        {
            // get random project and remove it from the list
            string projectName = projectNames[rng.Next(0, projectNames.Count)];
            projectNames.Remove(projectName);

            var projects = new List<Project>();
            for (int i = 0; i < rng.Next(1, 6); i++)
            {
                DateTime randomDate = GetRandomDate(new DateTime(), DateTime.Now, rng);
                State randomState = (State)rng.Next(0, 2);

                projects.Add(new Project(projectName, randomDate, randomState));
            }

            return projects.ToArray();
        }

        private static DateTime GetRandomDate(DateTime from, DateTime to, Random rng)
        {
            TimeSpan range = to - from;
            TimeSpan randomTimeSpan = new TimeSpan((long)(rng.NextDouble() * range.Ticks));
            return from + randomTimeSpan;
        }
    }
}
