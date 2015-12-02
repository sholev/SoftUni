using System.Collections.Generic;
using System.Linq;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Classes.Person.Employee.RegularEmployee
{
    class SalesEmployee : Employee, ISalesEmployee
    {
        public IEnumerable<ISale> Sales { get; set; }

        public SalesEmployee(uint id, string name, string surname, Department department, decimal salary, params ISale[] sales)
            : base(id, name, surname, department, salary)
        {
            this.Sales = sales;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Has {Sales.Count()} sales under the belt.";
        }
    }
}
