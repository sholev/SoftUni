namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface IWasteDisposalController
    {
        string Dispose(string type, string name, double weight, double volumePerKg);

        string Status();
    }
}