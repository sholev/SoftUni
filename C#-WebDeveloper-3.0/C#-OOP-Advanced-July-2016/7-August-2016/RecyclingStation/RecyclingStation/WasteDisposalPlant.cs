namespace RecyclingStation
{
    using System;

    using RecyclingStation.IO;
    using RecyclingStation.IO.Interfaces;
    using RecyclingStation.WasteDisposal.Controller;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class WasteDisposalPlant
    {
        private IWasteDisposalController wasteDisposalController;

        private IInputReader inputReader;

        private IOutputWriter outputWriter;

        public WasteDisposalPlant()
            : this(new WasteDisposalController(), new ConsoleIO(), new ConsoleIO())
        {
        }

        public WasteDisposalPlant(
            IWasteDisposalController wasteDisposalController,
            IInputReader inputReader,
            IOutputWriter outputWriter)
        {
            this.wasteDisposalController = wasteDisposalController;
            this.inputReader = inputReader;
            this.outputWriter = outputWriter;
        }

        public void StartWasteDisposal(string endCommand = "TimeToRecycle")
        {
            string command;
            while ((command = this.inputReader.ReadInput()) != endCommand)
            {
                string output = null;
                var commandParameters = command.Split(' ');
                switch (commandParameters[0])
                {
                    case "ProcessGarbage":
                        var garbageParameters = commandParameters[1].Split('|');

                        var name = garbageParameters[0];
                        var weight = double.Parse(garbageParameters[1]);
                        var volumePerKg = double.Parse(garbageParameters[2]);
                        var type = garbageParameters[3];

                        output = this.wasteDisposalController.Dispose(type, name, weight, volumePerKg);

                        break;
                    case "ChangeManagementRequirement":
                        throw new NotImplementedException();
                        break;
                    case "Status":
                        output = this.wasteDisposalController.Status();
                        break;

                    default:
                        throw new ArgumentException();
                }

                if (output != null)
                {
                    this.outputWriter.WriteOutput(output);
                    output = null;
                }
            }
        }
    }
}
