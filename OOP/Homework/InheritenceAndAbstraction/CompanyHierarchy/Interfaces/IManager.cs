using System.Collections.Generic;

namespace CompanyHierarchy.Interfaces
{
    interface IManager : IEmployee
    {
        IEnumerable<IEmployee> Employees { get; set; }
    }
}
