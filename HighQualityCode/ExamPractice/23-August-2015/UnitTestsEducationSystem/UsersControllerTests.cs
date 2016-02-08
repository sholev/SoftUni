// ReSharper disable InconsistentNaming
namespace UnitTestsEducationSystem
{
    using System;

    using EducationSystem.Controllers;
    using EducationSystem.Core;
    using EducationSystem.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UsersControllerTests
    {
        private UsersController testUsersControllerNullUser;
        private UsersController testUsersControllerExistingUser;
        private User testUser;

        [TestInitialize]
        public void InitializeTestData()
        {
            this.testUser = new User("Mocky Mockington", "TisASecret", default(Role));
            this.testUsersControllerNullUser = new UsersController(null, null);
            this.testUsersControllerExistingUser = new UsersController(null, this.testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUsersControllerNullUser_Logout_ThrowsException()
        {
            this.testUsersControllerNullUser.Logout();
        }

        ////// This test seems unnecessary, since there is no way this exception will be thrown.
        ////[TestMethod]
        ////[ExpectedException(typeof(AuthorizationFailedException))]
        ////public void TestUsersControllerUnauthorizedUser_Logout_ThrowsException()
        ////{
        ////    //this.testUsersControllerExistingUser.User.Role = A wrong role isn't possible?

        ////    this.testUsersControllerExistingUser.Logout();
        ////}

        [TestMethod]
        public void TestUsersController_Logout_UserLoggedOut()
        {
            this.testUsersControllerExistingUser.Logout();

            var currentUser = this.testUsersControllerExistingUser.User;

            Assert.IsNull(currentUser, "The user did not logout properly.");
        }
    }
}
