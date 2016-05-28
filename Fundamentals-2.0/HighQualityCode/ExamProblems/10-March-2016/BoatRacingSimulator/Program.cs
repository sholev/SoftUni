namespace BoatRacingSimulator
{
    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Core;
    using BoatRacingSimulator.Database;

    public class Program
    {
        public static void Main()
        {
            var boatSimulatorDatabase = new BoatSimulatorDatabase();
            var boatSimulatorController = new BoatSimulatorController(boatSimulatorDatabase);
            var commandHandler = new CommandHandler(boatSimulatorController);
            var engine = new Engine(commandHandler);
            engine.Run();
        }
    }
}
