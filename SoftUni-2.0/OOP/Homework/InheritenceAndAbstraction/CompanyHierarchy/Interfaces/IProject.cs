namespace CompanyHierarchy.Interfaces
{
    using System;

    using global::CompanyHierarchy.Enumerations;

    public interface IProject
    {
        string Name { get; set; }

        DateTime StartDate { get; set; }

        State State { get; set; }
    }
}
