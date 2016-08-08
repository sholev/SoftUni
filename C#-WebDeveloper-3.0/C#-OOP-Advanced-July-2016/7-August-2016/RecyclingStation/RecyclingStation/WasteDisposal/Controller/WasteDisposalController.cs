namespace RecyclingStation.WasteDisposal.Controller
{
    using System;

    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal.Models;
    using RecyclingStation.WasteDisposal.Models.Waste;
    using RecyclingStation.WasteDisposal.Strategy;

    public class WasteDisposalController : IWasteDisposalController
    {
        private IProcessingData currentProcessingData;

        private IGarbageProcessor garbageProcessor;

        public WasteDisposalController()
            : this(new ProcessingData(), new GarbageProcessor())
        {
        }

        public WasteDisposalController(
            IProcessingData currentProcessingData,
            IGarbageProcessor garbageProcessor)
        {
            this.currentProcessingData = currentProcessingData;
            this.garbageProcessor = garbageProcessor;
        }

        public string Dispose(string type, string name, double weight, double volumePerKg)
        {
            IProcessingData result = null;

            var garbageType = Type.GetType($"RecyclingStation.WasteDisposal.Models.Waste.{type}Waste");
            if (garbageType != null)
            {
                var instantiatedGarbage = Activator.CreateInstance(garbageType, name, weight, volumePerKg) as Waste;
                result = this.garbageProcessor.ProcessWaste(instantiatedGarbage);

                this.currentProcessingData = new ProcessingData(
                    this.currentProcessingData.EnergyBalance + result.EnergyBalance,
                    this.currentProcessingData.CapitalBalance + result.CapitalBalance);
            }
            else
            {
                throw new ArgumentException($"{type} is an invalid garbage type.");
            }

            return $"{weight:f2} kg of {name} successfully processed!";
        }

        public string Status()
        {
            var energy = this.currentProcessingData.EnergyBalance;
            var capital = this.currentProcessingData.CapitalBalance;

            return $"Energy: {energy:f2} Capital: {capital:f2}";
        }
    }
}
