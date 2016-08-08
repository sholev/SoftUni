namespace RecyclingStation.WasteDisposal.Models
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public class ProcessingData : IProcessingData
    {
        public ProcessingData()
            : this(0.0, 0.0)
        {
        }

        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double EnergyBalance { get; }

        public double CapitalBalance { get; }
    }
}
