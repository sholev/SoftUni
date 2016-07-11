namespace SystemSplit.Models.Software
{
    public class LightSoftware : SoftwareComponent
    {
        private const string ComponentType = "Light";
        
        public LightSoftware(string name, long capacityConsumption, long memoryConsuption)
            : base(name, ComponentType, capacityConsumption, memoryConsuption)
        {
        }

        public override long Capacity => base.Capacity + ((base.Capacity * 2) / 4);

        public override long Memory => base.Memory - ((base.Memory * 2) / 4);
    }
}
