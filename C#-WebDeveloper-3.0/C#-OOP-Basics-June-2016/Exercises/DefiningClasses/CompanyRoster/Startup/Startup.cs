namespace CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = parameters[0];
                var salary = decimal.Parse(parameters[1]);
                var position = parameters[2];
                var department = parameters[3];

                string email = null;
                int? age = null;
                if (parameters.Length > 4)
                {
                    if (parameters[4].Contains("@"))
                    {
                        email = parameters[4];
                    }
                    else
                    {
                        age = int.Parse(parameters[4]);
                    }

                    if (parameters.Length == 6)
                    {
                        if (email != null)
                        {
                            age = int.Parse(parameters[5]);
                        }
                        else
                        {
                            email = parameters[5];
                        }
                    }
                }

                employees.Add(new Employee(name, salary, position, department, email, age));
            }

            var result = employees
                .GroupBy(e => e.Department)
                .OrderByDescending(d => d.Sum(e => e.Salary))
                .First()
                .OrderByDescending(e => e.Salary);

            Console.WriteLine($"Highest Average Salary: {result.First().Department}");
            foreach (Employee employee in result)
            {
                Console.WriteLine(employee);
            }
        }
    }
}