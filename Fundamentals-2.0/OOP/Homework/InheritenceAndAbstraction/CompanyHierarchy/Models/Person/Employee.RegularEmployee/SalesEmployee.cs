namespace CompanyHierarchy.Models.Person.Employee.RegularEmployee
{
    using System.Collections.Generic;
    using System.Linq;

    using global::CompanyHierarchy.Enumerations;
    using global::CompanyHierarchy.Interfaces;
    using global::CompanyHierarchy.Models.Person.Employee;

    internal class SalesEmployee : Employee, ISalesEmployee
    {
        public IEnumerable<ISale> Sales { get; set; }

        public SalesEmployee(uint id, string name, string surname, Department department, decimal salary, params ISale[] sales)
            : base(id, name, surname, department, salary)
        {
            this.Sales = sales;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Has {this.Sales.Count()} sales under the belt.";
        }
    }
}
