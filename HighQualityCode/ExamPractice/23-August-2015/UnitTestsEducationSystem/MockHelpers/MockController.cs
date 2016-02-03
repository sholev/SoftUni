namespace UnitTestsEducationSystem.MockHelpers
{
    using EducationSystem.Controllers;
    using EducationSystem.Model;

    public class MockController : Controller
    {
        public MockController(User user)
        {
            this.User = user;
        }

        public void ExposedEnsureAuthorization(params Role[] roles)
        {
            this.EnsureAuthorization(roles);
        }
    }
}
