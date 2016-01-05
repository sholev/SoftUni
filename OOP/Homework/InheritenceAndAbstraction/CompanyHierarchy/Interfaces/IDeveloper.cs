namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    interface IDeveloper : IEmployee
    {
        IEnumerable<IProject> Projects { get; set; }
    }
}
