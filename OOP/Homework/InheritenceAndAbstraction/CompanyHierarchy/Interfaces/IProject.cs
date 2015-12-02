using System;

namespace CompanyHierarchy.Interfaces
{
    enum State
    {
        OPEN,
        CLOSED
    }

    interface IProject
    {
        string Name { get; set; }
        DateTime StartDate { get; set; }
        State State { get; set; }
    }
}
