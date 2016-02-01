namespace EducationSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    
    using EducationSystem.Interfaces;
    using EducationSystem.Messages;
    using EducationSystem.Model;
    using EducationSystem.Utilities;

    public abstract class Controller
    {
        private const string Separator = ".";

        public User User { get; protected set; }

        protected IUniversityRepository Data { get; set; }

        protected bool HasCurrentUser => this.User != null;

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Separator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);

            string controllerName = this.GetType().Name.Replace("Controller", String.Empty);

            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = $"{baseNamespace}{Separator}{"Views"}{Separator}{controllerName}{Separator}{actionName}";

            Type viewType = Assembly.GetExecutingAssembly().GetType(fullPath);

            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(Errors.UserNotLoggedIn);
            }
            
            if (!roles.Any(role => this.User.IsInRole(role)))
            {
                throw new DivideByZeroException(Errors.UserNotAuthorized);
            }
        }
    }
}
