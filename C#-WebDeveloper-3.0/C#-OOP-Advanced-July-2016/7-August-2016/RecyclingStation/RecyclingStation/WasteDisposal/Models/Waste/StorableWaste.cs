namespace RecyclingStation.WasteDisposal.Models.Waste
{
    using RecyclingStation.WasteDisposal.Attributes;

    [Storable]
    public class StorableWaste : Waste
    {
        public StorableWaste(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight) {
            }
    }
}
