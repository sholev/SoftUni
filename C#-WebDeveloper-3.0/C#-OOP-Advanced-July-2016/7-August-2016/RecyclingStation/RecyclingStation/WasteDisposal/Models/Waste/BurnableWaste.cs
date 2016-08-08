namespace RecyclingStation.WasteDisposal.Models.Waste
{
    using RecyclingStation.WasteDisposal.Attributes;

    [Burnable]
    public class BurnableWaste : Waste
    {
        public BurnableWaste(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight) {
            }
    }
}
