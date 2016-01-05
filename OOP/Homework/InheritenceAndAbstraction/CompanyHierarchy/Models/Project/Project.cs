namespace CompanyHierarchy.Models.Project
{
    using System;

    using global::CompanyHierarchy.Enumerations;
    using global::CompanyHierarchy.Interfaces;

    internal class Project : IProject
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public State State { get; set; }

        public Project(string name, DateTime startDate, State state)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.State = state;
        }

        public override string ToString()
        {
            return $"Project: {this.Name,-15} Started at: {this.StartDate.Date,-15} State: {this.State}";
        }
    }
}
