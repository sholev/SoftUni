namespace EducationSystem.Model
{
    using System;
    using System.Collections.Generic;

    using EducationSystem.Core;
    using EducationSystem.Utilities;
    using EducationSystem.Views;

    public class User
    {
        private string userName;

        private string passwordHash;

        public User(string username, string password, Role role)
        {
            this.UserName = username;
            this.PasswordHash = HashUtilities.HashPassword(password);
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(Messages.GetLengthMessage("username", 5));
                }

                this.userName = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    throw new ArgumentException(Messages.GetLengthMessage("password", 6));
                }

                this.passwordHash = value;
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}