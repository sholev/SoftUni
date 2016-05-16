namespace EducationSystem.Model
{
    using System;
    using System.Collections.Generic;

    using EducationSystem.Messages;
    using EducationSystem.Utilities;

    public class User
    {
        private string userName;

        ////private string passwordHash;

        public User(string username, string password, Role role)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                throw new ArgumentException(Errors.StringLength("password", 6));
            }

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
                    throw new ArgumentException(Errors.StringLength("username", 5));
                }

                this.userName = value;
            }
        }

        public string PasswordHash { get; }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}