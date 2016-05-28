namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Enumerations;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;
    using BoatRacingSimulator.Utility;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(IBoatSimulatorDatabase database, IRace currentRace = null)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController()
            : this(new BoatSimulatorDatabase())
        {
        }

        public IRace CurrentRace { get; private set; }

        public IBoatSimulatorDatabase Database { get; private set; }

        /// <summary>
        /// Create a new engine for the boats.
        /// </summary>
        /// <param name="model">Unique model name for the <see cref="IBoatEngine"/>.</param>
        /// <param name="horsepower">Horsepower amount for the <see cref="IBoatEngine"/>.</param>
        /// <param name="displacement">Displacement amount for the <see cref="IBoatEngine"/>.</param>
        /// <param name="engineType"><see cref="EngineType"/> for the <see cref="IBoatEngine"/>.</param>
        /// <returns>Returns a string with information about the newly created <see cref="IBoatEngine"/>.</returns>
        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IBoatEngine engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.Database.Engines.Add(engine);

            return string.Format(
                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.",
                model,
                horsepower,
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat rowBoat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(rowBoat);

            return string.Format("Row boat with model {0} registered successfully.", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);

            return string.Format("Sail boat with model {0} registered successfully.", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            var firstEngine = this.Database.Engines.GetItem(firstEngineModel);
            var secondEngine = this.Database.Engines.GetItem(secondEngineModel);
            IBoat boat = new PowerBoat(model, weight, new List<IBoatEngine> { firstEngine, secondEngine });
            this.Database.Boats.Add(boat);

            return string.Format("Power boat with model {0} registered successfully.", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            var engine = this.Database.Engines.GetItem(engineModel);
            IBoat boat = new Yacht(model, weight,  engine, cargoWeight);
            this.Database.Boats.Add(boat);

            return string.Format("Yacht with model {0} registered successfully.", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            Validator.ValidateRaceIsEmpty(this.CurrentRace);
            this.CurrentRace = race;

            return
                string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    distance,
                    windSpeed,
                    oceanCurrentSpeed);
        }

        /// <summary>
        /// Add an <see cref="IBoat"/> participant from the boats database to the current <see cref="IRace"/>.
        /// </summary>
        /// <param name="model">The string of the boat model.</param>
        /// <returns>A message containing information about the added <see cref="IBoat"/>.</returns>
        public string SignUpBoat(string model)
        {
            var boat = this.Database.Boats.GetItem(model);
            Validator.ValidateRaceIsSet(this.CurrentRace);
            if (!this.CurrentRace.AllowsMotorboats && (boat is Yacht || boat is PowerBoat))
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.CurrentRace.AddParticipant(boat);

            return string.Format("Boat with model {0} has signed up for the current Race.", model);
        }

        public string StartRace()
        {
            Validator.ValidateRaceIsSet(this.CurrentRace);
            var participants = this.CurrentRace.GetParticipants();

            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var result = new StringBuilder();
            participants = participants.OrderBy(p => this.CalculateTime(p, this.CurrentRace)).ToArray();
            for (int i = 0; i < 3; i++)
            {
                var participantTime = this.CalculateTime(participants[i], this.CurrentRace);
                result.AppendLine(string.Format(
                    "{0} place: {1} Model: {2} Time: {3}",
                    this.PlaceToWord(i),
                    participants[i].GetType().Name,
                    participants[i].Model,
                    double.IsInfinity(participantTime) ? "Did not finish!" : participantTime.ToString("0.00") + " sec"));
            }

            this.CurrentRace = null;

            return result.ToString();
        }

        public string GetStatistic()
        {
            var participants = this.CurrentRace.GetParticipants();

            double totalBoats = 0;
            int rowBoats = 0;
            int sailBoats = 0;
            int powerBoats = 0;
            int yachts = 0;

            if (participants != null && participants.Count != 0)
            {
                totalBoats = participants.Count;
                foreach (IBoat participant in participants)
                {
                    if (participant is RowBoat)
                    {
                        rowBoats++;
                    }
                    else if (participant is SailBoat)
                    {
                        sailBoats++;
                    }
                    else if (participant is PowerBoat)
                    {
                        powerBoats++;
                    }
                    else
                    {
                        yachts++;
                    }
                }
            }

            string output = string.Format(
                "PowerBoat -> {0:f2}%\r\nRowBoat -> {1:f2}%\r\nSailBoat -> {2:f2}%\r\nYacht -> {3:f2}%",
                (powerBoats / totalBoats) * 100,
                (rowBoats / totalBoats) * 100,
                (sailBoats / totalBoats) * 100,
                (yachts / totalBoats) * 100);

            return output;
        }

        private string PlaceToWord(int place)
        {
            switch (place)
            {
                case 0:
                    return "First";
                case 1:
                    return "Second";
                case 2:
                    return "Third";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private double CalculateTime(IBoat participant, IRace race)
        {
            var speed = participant.CalculateRaceSpeed(race);
            var time = this.CurrentRace.Distance / speed;
            time = time < 0 ? double.PositiveInfinity : time;

            return time;
        }
    }
}
