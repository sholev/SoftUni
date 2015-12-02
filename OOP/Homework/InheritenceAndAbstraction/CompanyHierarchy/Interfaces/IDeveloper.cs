using System.Collections.Generic;

namespace CompanyHierarchy.Interfaces
{
    interface IDeveloper : IEmployee
    {
        IEnumerable<IProject> Projects { get; set; }
    }
}
