namespace RecyclingStation.WasteDisposal.Models.Waste
{
    using RecyclingStation.WasteDisposal.Interfaces;

    public abstract class Waste : IWaste
    {
        protected Waste(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.Weight = weight;
            this.VolumePerKg = volumePerKg;
        }

        public string Name { get; }

        public double Weight { get; }

        public double VolumePerKg { get; }
    }
}
