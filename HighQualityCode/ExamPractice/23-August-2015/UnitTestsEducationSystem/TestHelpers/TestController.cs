namespace UnitTestsEducationSystem.TestHelpers
{
    using EducationSystem.Controllers;
    using EducationSystem.Model;

    public class TestController : Controller
    {
        public TestController(User user)
        {
            this.User = user;
        }

        public void ExposedEnsureAuthorization(params Role[] roles)
        {
            this.EnsureAuthorization(roles);
        }
    }
}
