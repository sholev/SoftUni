namespace SystemSplit.Models.Hardware
{
    public class HeavyHardware : HardwareComponent
    {
        private const string ComponentType = "Heavy";
        public HeavyHardware(string name, long maxCapacity, long maxMemory)
            : base(name, ComponentType, maxCapacity, maxMemory)
        {
        }

        public override long Capacity => base.Capacity * 2;

        public override long Memory => base.Memory - (base.Memory / 4);
    }
}
