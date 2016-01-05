namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IManager : IEmployee
    {
        IEnumerable<IEmployee> Employees { get; set; }
    }
}
