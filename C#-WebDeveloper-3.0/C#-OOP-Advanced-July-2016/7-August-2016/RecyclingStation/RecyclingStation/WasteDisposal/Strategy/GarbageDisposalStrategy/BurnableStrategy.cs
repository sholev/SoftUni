namespace RecyclingStation.WasteDisposal.Strategy.GarbageDisposalStrategy
{
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal.Models;

    public class BurnableStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var totalGarbageVolume = garbage.Weight * garbage.VolumePerKg;
            var energyProduced = totalGarbageVolume;
            var energyUsed = totalGarbageVolume * 0.2;

            var energyBalance = energyProduced - energyUsed;

            var capitalBalance = 0;

            var processingData = new ProcessingData(energyBalance, capitalBalance);

            return processingData;
        }
    }
}
