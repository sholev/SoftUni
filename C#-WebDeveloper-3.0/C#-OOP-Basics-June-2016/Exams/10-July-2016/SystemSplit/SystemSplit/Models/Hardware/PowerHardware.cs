namespace SystemSplit.Models.Hardware
{
    public class PowerHardware : HardwareComponent
    {
        private const string ComponentType = "Power";

        public PowerHardware(string name, long maxCapacity, long maxMemory)
            : base(name, ComponentType, maxCapacity, maxMemory)
        {

        }

        public override long Capacity => base.Capacity - ((base.Capacity * 3) / 4);

        public override long Memory => base.Memory + ((base.Memory * 3) / 4);
    }
}
