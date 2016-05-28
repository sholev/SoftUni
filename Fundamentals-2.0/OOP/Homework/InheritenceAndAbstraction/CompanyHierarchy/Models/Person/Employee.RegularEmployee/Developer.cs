namespace CompanyHierarchy.Models.Person.Employee.RegularEmployee
{
    using System.Collections.Generic;
    using System.Linq;

    using global::CompanyHierarchy.Enumerations;
    using global::CompanyHierarchy.Interfaces;
    using global::CompanyHierarchy.Models.Person.Employee;

    internal class Developer : Employee, IDeveloper
    {
        public IEnumerable<IProject> Projects { get; set; }

        public Developer(uint id, string name, string surname, Department department, decimal salary, params IProject[] projects)
            : base(id, name, surname, department, salary)
        {
            this.Projects = projects;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Has {this.Projects.Count()} projects.";
        }
    }
}
