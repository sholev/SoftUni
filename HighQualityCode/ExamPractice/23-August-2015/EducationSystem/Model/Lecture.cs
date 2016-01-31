namespace EducationSystem.Model
{
    using System;

    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            this.Name = this.Name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null || value.Length < 3)
                {
                    throw new ArgumentException("The lecture name must be at least 3 symbols long.");
                }

                this.name = value;
            }
        }
    }
}