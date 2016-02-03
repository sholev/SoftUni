// Those tests are not in the requirements of the problem.
// Made them bucause I was reading the wrong problem T_T.
// ReSharper disable InconsistentNaming
namespace UnitTestsEducationSystem
{
    using System;

    using EducationSystem.Core;
    using EducationSystem.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MockController = UnitTestsEducationSystem.MockHelpers.MockController;

    [TestClass]
    public class ControllerTests
    {
        private User mockUserNull;
        private User mockUser;
        private MockController mockController;
        private MockController mockControllerNullUser;

        [TestInitialize]
        public void InitializeTestController()
        {
            this.mockUserNull = null;
            this.mockControllerNullUser = new MockController(this.mockUserNull);

            this.mockUser = new User("Mocky Mockington", "TisASecret", Role.Student);
            this.mockController = new MockController(this.mockUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MockedControllerNullUser_EnsureAuthorization_ThrowsException()
        {
            this.mockControllerNullUser.ExposedEnsureAuthorization(Role.Student, Role.Lecturer);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void MockedController_EnsureAuthorization_ThrowsException()
        {
            this.mockController.ExposedEnsureAuthorization(Role.Lecturer);
        }
    }
}
