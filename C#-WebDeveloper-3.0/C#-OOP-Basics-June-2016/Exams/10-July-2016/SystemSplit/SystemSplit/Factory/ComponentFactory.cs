namespace SystemSplit.Factory
{
    using SystemSplit.Models.Hardware;
    using SystemSplit.Models.Software;

    public class ComponentFactory
    {
        public PowerHardware RegisterPowerHardware(string name, long capacity, long memory)
        {
            return new PowerHardware(name, capacity, memory);
        }

        public HeavyHardware RegisterHeavyHardware(string name, long capacity, long memory)
        {
            return new HeavyHardware(name, capacity, memory);
        }

        public ExpressSoftware RegisterExpressSoftware(string name, long capacity, long memory)
        {
            return new ExpressSoftware(name, capacity, memory);
        }

        public LightSoftware RegisterLightSoftware(string name, long capacity, long memory)
        {
            return new LightSoftware(name, capacity, memory);
        }
    }
}
