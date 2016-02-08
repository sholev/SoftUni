// Disabled to avoid warnings about underscore test names:
// ReSharper disable InconsistentNaming
namespace UnitTests
{
    using System.Linq;

    using AC_TestingSystem.Data;
    using AC_TestingSystem.Exceptions;
    using AC_TestingSystem.Interfaces;
    using AC_TestingSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryTests
    {
        private AirConditioner testAirConditioner;

        private Report[] testReports;

        private Repository testRepository;

        private string[] testManufacturers;

        [TestInitialize]
        public void InitializeTestController()
        {
            this.testManufacturers = new [] { "SomeManufacturer", "SomeManufacturer" };
            string[] testModels = { "SomeModel", "AnotherModel"};
            string[] testEnergyEfficiencyRatings = { "A", "B" };

            const int TestMark = 0;
            const int TestPowerUsage = 5;
            const int NumberOfReports = 2;

            this.testAirConditioner = 
                new AirConditioner(
                    this.testManufacturers[0],
                    testModels[0],
                    testEnergyEfficiencyRatings[0],
                    TestPowerUsage);

            this.testReports = new Report[NumberOfReports];

            for (int i = 0; i < NumberOfReports; i++)
            {
                this.testReports[i] = new Report(this.testManufacturers[i], testModels[i], TestMark);
            }

            this.testRepository = new Repository();
        }

        [TestMethod]
        public void Repository_AddAirConditioner_AddSuccessful()
        {
            this.testRepository.AddAirConditioner(this.testAirConditioner);

            var addedAirConditioner = this.testRepository.GetAirConditioner(
                this.testAirConditioner.Manufacturer,
                this.testAirConditioner.Model);

            // TODO: Assuming GetAirConditioner is correct, should test if the time allows.
            Assert.AreEqual(this.testAirConditioner, addedAirConditioner, "Added Air Conditioner is not added properly");
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void Repository_AddAirConditioner_ThrowsException()
        {
            this.testRepository.AddAirConditioner(this.testAirConditioner);
            this.testRepository.AddAirConditioner(this.testAirConditioner);
        }

        [TestMethod]
        public void Repository_FindAllReportsByManufacturer_ReportsFound()
        {
            // TODO: Assuming AddReport is correct, should test if the time allows.
            foreach (Report testReport in this.testReports)
            {
                this.testRepository.AddReport(testReport);
            }

            var reportsByManufacturer = this.testRepository
                .GetReportsByManufacturer(this.testManufacturers.FirstOrDefault())
                .ToArray();

            var reportsAreCorrect = reportsByManufacturer.All(r => this.testManufacturers.Contains(r.Manufacturer));

            Assert.IsTrue(reportsAreCorrect, "The method for finding all reports is incorrect.");
        }

        [TestMethod]
        public void Repository_FindAllReportsByManufacturer_NoReportsFound()
        {
            string unexistingManufacturer = "Potatoes";

            // TODO: Assuming AddReport is correct, should test if the time allows.
            foreach (Report testReport in this.testReports)
            {
                this.testRepository.AddReport(testReport);
            }

            var reportsByManufacturer = this.testRepository
                .GetReportsByManufacturer(unexistingManufacturer)
                .ToArray();

            var noReportsFound = reportsByManufacturer.Length == 0;

            Assert.IsTrue(noReportsFound, "Searching for unexisting reports did not return zero reports.");
        }
    }
}
