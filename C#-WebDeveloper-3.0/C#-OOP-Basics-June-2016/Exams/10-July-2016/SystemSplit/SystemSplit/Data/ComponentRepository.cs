namespace SystemSplit.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SystemSplit.Models.Hardware;
    using SystemSplit.Models.Software;

    public class ComponentRepository
    {
        private readonly Dictionary<string, HardwareComponent> hardwareComponents;

        private readonly Dictionary<string, HardwareComponent> dump;

        public ComponentRepository()
        {
            this.hardwareComponents = new Dictionary<string, HardwareComponent>();
            this.dump = new Dictionary<string, HardwareComponent>();
        }

        public void RegisterHardware(HardwareComponent hardware)
        {
            string hardwareName = hardware.Name;

            this.hardwareComponents.Add(hardwareName, hardware);
        }

        public void RegisterSoftware(string hardwareName, SoftwareComponent software)
        {
            string softwareName = software.Name;

            if (this.hardwareComponents.ContainsKey(hardwareName))
            {
                if (this.hardwareComponents[hardwareName].HasCapacityAndMemoryForGivenSoftware(software))
                {
                    this.hardwareComponents[hardwareName].RegisterSoftwareComponent(software);
                }
            }
        }

        public void ReleaseSoftware(string hardwareName, string softwareName)
        {
            if (this.hardwareComponents.ContainsKey(hardwareName))
            {
                this.hardwareComponents[hardwareName].ReleaseSoftwareComponent(softwareName);
            }
        }

        public void Dump(string hardwareName)
        {
            if (this.hardwareComponents.ContainsKey(hardwareName))
            {
                var dumpedHardware = this.hardwareComponents[hardwareName];
                this.hardwareComponents.Remove(hardwareName);
                this.dump.Add(hardwareName, dumpedHardware);
            }
        }

        public void Restore(string hardwareName)
        {
            if (this.dump.ContainsKey(hardwareName))
            {
                var restoredHardware = this.dump[hardwareName];
                this.dump.Remove(hardwareName);
                this.RegisterHardware(restoredHardware);
            }
        }

        public void Destroy(string hardwareName)
        {
            if (this.dump.ContainsKey(hardwareName))
            {
                this.dump.Remove(hardwareName);
            }
        }

        public string Analyze()
        {
            var hardwareComponentsCounnt = this.hardwareComponents.Count;
            var softwareComponentsCount = this.hardwareComponents.Values.Sum(h => h.SoftwareComponentsCount);
            var maximumMemory = this.hardwareComponents.Values.Sum(h => h.Memory);
            var totalOperationalMemoryInUse = this.hardwareComponents.Values.Sum(h => h.MemoryInUse);
            var maximumCapacity = this.hardwareComponents.Values.Sum(h => h.Capacity);
            var totalCapacityTaken = this.hardwareComponents.Values.Sum(h => h.CapacityInUse);

            var output = new StringBuilder();

            output.AppendLine("System Analysis");
            output.AppendLine($"Hardware Components: {hardwareComponentsCounnt}");
            output.AppendLine($"Software Components: {softwareComponentsCount}");
            output.AppendLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {maximumMemory}");
            output.Append($"Total Capacity Taken: {totalCapacityTaken} / {maximumCapacity}");

            return output.ToString();
        }

        public string DumpAnalyze()
        {
            var output = new StringBuilder();

            var countOfPowerHardwareComponents = this.dump.Values.Count(h => h.Type.Equals("Power"));
            var countOfHeavyHardwareComponents = this.dump.Values.Count(h => h.Type.Equals("Heavy"));
            var countOfExpressSoftwareComponents = this.dump.Values.Sum(h => h.ExpressSoftwareCount);
            var countOfLightSoftwareComponents = this.dump.Values.Sum(h => h.LigtSoftwareCount);
            var totalDumpedMemory = this.dump.Values.Sum(h => h.MemoryInUse);
            var totalDumpedCapacity = this.dump.Values.Sum(h => h.CapacityInUse);

            output.AppendLine("Dump Analysis");
            output.AppendLine($"Power Hardware Components: {countOfPowerHardwareComponents}");
            output.AppendLine($"Heavy Hardware Components: {countOfHeavyHardwareComponents}");
            output.AppendLine($"Express Software Components: {countOfExpressSoftwareComponents}");
            output.AppendLine($"Light Software Components: {countOfLightSoftwareComponents}");
            output.AppendLine($"Total Dumped Memory: {totalDumpedMemory}");
            output.Append($"Total Dumped Capacity: {totalDumpedCapacity}");

            return output.ToString();
        }

        public string SystemSplit()
        {
            var output = new StringBuilder();

            var components = this.hardwareComponents.Values.ToArray();
            for (int index = 0; index < components.Length; index++)
            {
                HardwareComponent component = components[index];

                if (index != components.Length - 1)
                {
                    output.AppendLine(component.ToString());
                }
                else
                {
                    output.Append(component);
                }
            }

            return output.ToString();
        }
    }
}