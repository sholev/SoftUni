using System;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Classes.Project
{
    class Project : IProject
    {
        private string name;
        private DateTime startDate;
        private State state;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        public Project(string name, DateTime startDate, State state)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.State = state;
        }

        public override string ToString()
        {
            return $"Project: {Name,-15} Started at: {StartDate.Date,-15} State: {State}";
        }
    }
}
