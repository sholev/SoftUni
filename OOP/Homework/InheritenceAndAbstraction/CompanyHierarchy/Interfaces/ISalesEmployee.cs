using System.Collections.Generic;

namespace CompanyHierarchy.Interfaces
{
    interface ISalesEmployee : IEmployee
    {
        IEnumerable<ISale> Sales { get; set; }
    }
}
