namespace SystemSplit.Models.Software
{
    public class ExpressSoftware : SoftwareComponent
    {
        private const string ComponentType = "Express";

        public ExpressSoftware(string name, long capacityConsumption, long memoryConsuption)
            : base(name, ComponentType, capacityConsumption, memoryConsuption)
        {
        }

        public override long Memory => base.Memory * 2;
    }
}