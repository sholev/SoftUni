namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface ISalesEmployee : IEmployee
    {
        IEnumerable<ISale> Sales { get; set; }
    }
}
