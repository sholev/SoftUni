namespace RecyclingStation.WasteDisposal.Strategy.GarbageDisposalStrategy
{
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal.Models;

    public class RecyclableStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var totalGarbageVolume = garbage.Weight * garbage.VolumePerKg;
            var energyProduced = 0;
            var energyUsed = totalGarbageVolume * 0.5;

            var energyBalance = energyProduced - energyUsed;

            var capitalEarned = 400 * garbage.Weight;

            var capitalBalance = capitalEarned;

            var processingData = new ProcessingData(energyBalance, capitalBalance);

            return processingData;
        }
    }
}
