// Those tests are not in the requirements of the problem.
// Made them bucause I was reading the wrong problem T_T.
// ReSharper disable InconsistentNaming
namespace UnitTestsEducationSystem
{
    using System;

    using EducationSystem.Core;
    using EducationSystem.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UnitTestsEducationSystem.TestHelpers;

    [TestClass]
    public class ControllerTests
    {
        private User testUserNull;
        private User testUser;
        private TestController testController;
        private TestController testControllerNullUser;

        [TestInitialize]
        public void InitializeTestController()
        {
            this.testUserNull = null;
            this.testControllerNullUser = new TestController(this.testUserNull);

            this.testUser = new User("Mocky Mockington", "TisASecret", Role.Student);
            this.testController = new TestController(this.testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestControllerNullUser_EnsureAuthorization_ThrowsException()
        {
            this.testControllerNullUser.ExposedEnsureAuthorization(Role.Student, Role.Lecturer);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void TestController_EnsureAuthorization_ThrowsException()
        {
            this.testController.ExposedEnsureAuthorization(Role.Lecturer);
        }
    }
}
