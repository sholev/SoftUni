using System.Collections.Generic;
using System.Linq;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Classes.Person.Employee
{
    class Manager : Employee, IManager
    {
        public IEnumerable<IEmployee> Employees { get; set; }

        public Manager(uint id, string name, string surname, Department department, decimal salary, IEnumerable<IEmployee> employees = null)
            : base(id, name, surname, department, salary)
        {
            this.Employees = employees;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Managing {Employees.Count()} employees.";
        }
    }
}
