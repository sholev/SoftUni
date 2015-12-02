using System.Collections.Generic;
using System.Linq;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Classes.Person.Employee.RegularEmployee
{
    class Developer : Employee, IDeveloper
    {
        public IEnumerable<IProject> Projects { get; set; }

        public Developer(uint id, string name, string surname, Department department, decimal salary, params IProject[] projects)
            : base(id, name, surname, department, salary)
        {
            this.Projects = projects;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Has {Projects.Count()} projects.";
        }
    }
}
