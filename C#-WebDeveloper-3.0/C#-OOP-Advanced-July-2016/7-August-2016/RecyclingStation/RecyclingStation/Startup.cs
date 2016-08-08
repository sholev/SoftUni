namespace RecyclingStation
{
    public class Startup
    {
        private static void Main(string[] args)
        {
            var wasteDisposalPlant = new WasteDisposalPlant();

            wasteDisposalPlant.StartWasteDisposal();
        }
    }
}
