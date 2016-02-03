namespace UnitTestsEducationSystem
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UnitTestsEducationSystem.MockHelpers;

    [TestClass]
    public class ViewTests
    {
        private MockView mockView;

        [TestInitialize]
        public void InitializeTestData()
        {
            this.mockView = new MockView("This is the seat with the best view, yay.");
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
