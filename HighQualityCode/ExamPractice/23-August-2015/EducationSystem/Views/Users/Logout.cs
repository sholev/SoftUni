namespace EducationSystem.Views.Users
{
    using System.Text;

    using EducationSystem.Model;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("User {0} logged out successfully.", user.UserName);
        }
    }
}