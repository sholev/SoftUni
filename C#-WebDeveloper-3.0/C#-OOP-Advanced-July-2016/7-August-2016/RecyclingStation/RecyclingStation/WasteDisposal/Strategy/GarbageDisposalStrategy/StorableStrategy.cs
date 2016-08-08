namespace RecyclingStation.WasteDisposal.Strategy.GarbageDisposalStrategy
{
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal.Models;

    public class StorableStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var totalGarbageVolume = garbage.Weight * garbage.VolumePerKg;
            var energyProduced = 0;
            var energyUsed = totalGarbageVolume * 0.13;

            var energyBalance = energyProduced - energyUsed;

            var capitalUsed = totalGarbageVolume * 0.65;

            var capitalBalance = -capitalUsed;

            var processingData = new ProcessingData(energyBalance, capitalBalance);

            return processingData;
        }
    }
}
