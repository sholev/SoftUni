namespace EducationSystem.Model
{
    using System;

    using EducationSystem.Messages;

    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            this.Name = name;
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
                    throw new ArgumentException(Errors.StringLength("lecture name", 3));
                }

                this.name = value;
            }
        }
    }
}