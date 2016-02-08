// ReSharper disable InconsistentNaming
namespace UnitTestsEducationSystem
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UnitTestsEducationSystem.TestHelpers;

    [TestClass]
    public class ViewTests
    {
        private TestView testView;

        private string testMessage;

        [TestInitialize]
        public void InitializeTestData()
        {
            this.testView = new TestView();
            this.testMessage = "This is the seat with the best view, yay.";
        }

        [TestMethod]
        public void TestView_Display_ReturnsViewMessage()
        {
            this.testView.Message = this.testMessage;

            Assert.AreEqual(this.testMessage, this.testView.Display(), "The Display result is incorrect.");
        }
    }
}
