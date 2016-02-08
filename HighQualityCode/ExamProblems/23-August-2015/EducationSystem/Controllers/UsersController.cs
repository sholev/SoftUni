namespace EducationSystem.Controllers
{
    using System;

    using EducationSystem.Core;
    using EducationSystem.Interfaces;
    using EducationSystem.Messages;
    using EducationSystem.Model;
    using EducationSystem.Utilities;

    public class UsersController : Controller
    {
        public UsersController(IUniversityRepository data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException(Errors.UserPasswordsNotMatching);
            }

            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser != null)
            {
                throw new ArgumentException(Errors.UserNameTaken(username));
            }

            Role userRole = (Role)Enum.Parse(typeof(Role), role, true);
            var user = new User(username, password, userRole);
            this.Data.Users.Add(user);
            return this.View(user);
        }

        public IView Login(string username, string password)
        {
            this.EnsureNoLoggedInUser();

            var existingUser = this.Data.Users.GetByUsername(username);
            if (existingUser == null)
            {
                throw new ArgumentException(Errors.UserDoesNotExist(username));
            }

            if (existingUser.PasswordHash != HashUtilities.HashPassword(password))
            {
                throw new ArgumentException(Errors.UserPasswordIsWrong);
            }

            this.User = existingUser;
            return this.View(existingUser);
        }

        public IView Logout()
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Errors.UserNotLoggedIn);
            }

            if (!this.User.IsInRole(Role.Lecturer) && !this.User.IsInRole(Role.Student))
            {
                throw new AuthorizationFailedException(Errors.UserNotAuthorized);
            }

            var user = this.User;
            this.User = null;
            return this.View(user);
        }

        private void EnsureNoLoggedInUser()
        {
            if (this.HasCurrentUser)
            {
                throw new ArgumentException(Errors.UserAlreadyLoggedIn);
            }
        }
    }
}