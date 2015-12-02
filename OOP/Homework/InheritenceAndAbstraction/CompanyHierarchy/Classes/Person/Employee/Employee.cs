using System;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Classes.Person.Employee
{
    class Employee : Person, IEmployee
    {
        private decimal salary;

        public Department Department { get; set; }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (this.salary < 0M)
                {
                    throw new ArgumentOutOfRangeException("Employee salary should not be negative.");
                }
                this.salary = value;
            }
        }

        public Employee(uint id, string name, string surname, Department department, decimal salary)
            : base(id, name, surname)
        {
            this.Department = department;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Department: {Department,-15} Salary: {Salary:F2}";
        }

    }
}
