namespace UnitTestTheaters
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Theaters.Business;
    using Theaters.Interfaces;

    // I didn't have time to finish this T_T
    [TestClass]
    public class UnitTestsForIPerformanceDatabase
    {
        private string[] theaterNames;

        private IPerformanceDatabase database;

        [TestInitialize]
        public void InitializeTestData()
        {
            this.theaterNames = new[] { "The Emporium", "The Wards", "The Presidium" };
            this.database = new PerformanceDatabase();
        }

        [TestMethod]
        public void PerformanceDatabase_ListTheaters_TheatersReturned()
        {
            foreach (string theaterName in this.theaterNames)
            {
                this.database.AddTheater(theaterName);
            }

            var theatersAdded = this.theaterNames.All(theater => this.database.ListTheaters().Contains(theater));

            Assert.AreEqual(true, theatersAdded, "The database does not properly return all theaters.");
        }
    }
}
