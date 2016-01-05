namespace CompanyHierarchy.Models.Person.Employee.Manager
{
    using System.Collections.Generic;
    using System.Linq;

    using global::CompanyHierarchy.Enumerations;
    using global::CompanyHierarchy.Interfaces;
    using global::CompanyHierarchy.Models.Person.Employee;

    internal class Manager : Employee, IManager
    {
        public IEnumerable<IEmployee> Employees { get; set; }

        public Manager(uint id, string name, string surname, Department department, decimal salary, IEnumerable<IEmployee> employees = null)
            : base(id, name, surname, department, salary)
        {
            this.Employees = employees;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Managing {this.Employees.Count()} employees.";
        }
    }
}
