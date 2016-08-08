namespace RecyclingStation.WasteDisposal.Models.Waste
{
    using RecyclingStation.WasteDisposal.Attributes;

    [Recyclable]
    public class RecyclableWaste : Waste
    {
        public RecyclableWaste(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight) {
            }
    }
}
