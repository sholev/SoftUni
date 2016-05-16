// ReSharper disable InconsistentNaming
namespace UnitTestsBoatRacingSimulator
{
    using System;
    using System.Collections.Generic;

    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BoatSimulatorControllerUnitTests
    {
        private BoatSimulatorController testController;

        [TestInitialize]
        public void InitializeTestController()
        {
            this.testController = new BoatSimulatorController();
        }

        [TestMethod]
        public void OpenRace_CorrectData_RaceIsNull()
        {
            Assert.IsNull(this.testController.CurrentRace);
        }

        [TestMethod]
        public void OpenRace_CorrectData_RaceIsNotNull()
        {
            int distance = 1000;
            int windSpeed = 10;
            int oceanCurrentSpeed = 5;
            bool allowsMotorboats = true;

            this.testController.OpenRace(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);

            Assert.IsNotNull(this.testController.CurrentRace);
        }

        [TestMethod]
        public void OpenRace_CorrectData_Successful()
        {
            int distance = 1000;
            int windSpeed = 10;
            int oceanCurrentSpeed = 5;
            bool allowsMotorboats = true;

            string expectedResult =
                String.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    distance,
                    windSpeed,
                    oceanCurrentSpeed);

            string result = this.testController.OpenRace(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void OpenRace_DistanceWrong_ThrowsException()
        {
            int distance = 0;
            int windSpeed = 10;
            int oceanCurrentSpeed = 5;
            bool allowsMotorboats = true;

            this.testController.OpenRace(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyExistsException))]
        public void OpenRace_WindSpeedWrong_ThrowsException()
        {
            int distance = 1000;
            int windSpeed = 10;
            int oceanCurrentSpeed = 5;
            bool allowsMotorboats = true;

            this.testController.OpenRace(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.testController.OpenRace(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSetRaceException))]
        public void StartRace_NoRaceSet_ThrowsException()
        {
            this.testController.StartRace();
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientContestantsException))]
        public void StartRace_NoContestants_ThrowsException()
        {
            int distance = 1000;
            int windSpeed = 10;
            int oceanCurrentSpeed = 5;
            bool allowsMotorboats = true;

            this.testController.OpenRace(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);

            this.testController.StartRace();
        }

        [TestMethod]
        public void StartRace_AddedContestants_RaceProperlyFinished()
        {
            int distance = 1000;
            int windSpeed = 10;
            int oceanCurrentSpeed = 5;
            bool allowsMotorboats = true;

            var jetEngine = new JetEngine("GHP01", 250, 100);
            var sterndriveEngine = new SterndriveEngine("GHP01", 150, 150);
            
            var rowBoat = new RowBoat("Rower15", 450, 6);
            var powerBoat = new PowerBoat("PB150", 2200, new List<IBoatEngine> { jetEngine, sterndriveEngine });
            var sailBoat = new SailBoat("SailBoatPro", 200, 98);

            this.testController.OpenRace(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.testController.CurrentRace.AddParticipant(rowBoat);
            this.testController.CurrentRace.AddParticipant(powerBoat);
            this.testController.CurrentRace.AddParticipant(sailBoat);

            string result = this.testController.StartRace();
            string expectedResult = "First place: PowerBoat Model: PB150 Time: 2.85 sec" + Environment.NewLine
                                    + "Second place: RowBoat Model: Rower15 Time: 6.45 sec" + Environment.NewLine
                                    + "Third place: SailBoat Model: SailBoatPro Time: Did not finish!" + Environment.NewLine;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
