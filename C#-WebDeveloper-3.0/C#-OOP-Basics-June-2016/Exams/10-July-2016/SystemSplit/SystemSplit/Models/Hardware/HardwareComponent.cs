namespace SystemSplit.Models.Hardware
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SystemSplit.Models.Software;

    public abstract class HardwareComponent : Component
    {
        private readonly Dictionary<string, SoftwareComponent> softwareComonents;

        protected HardwareComponent(string name, string type, long maxCapacity, long maxMemory)
            : base(name, maxCapacity, maxMemory)
        {
            this.Type = type;
            this.softwareComonents = new Dictionary<string, SoftwareComponent>();
        }

        public string Type { get; }

        public long ExpressSoftwareCount { get; private set; }

        public long LigtSoftwareCount { get; private set; }

        public long MemoryInUse => this.softwareComonents.Values.Sum(s => s.Memory);

        public long CapacityInUse => this.softwareComonents.Values.Sum(s => s.Capacity);

        public long SoftwareComponentsCount => this.softwareComonents.Count;

        public IEnumerable<string> SoftwareComponentNames => this.softwareComonents.Values.Select(s => s.Name);

        protected long AvailableCapacity => this.Capacity - this.CapacityInUse;

        protected long AvailableMemory => this.Memory - this.MemoryInUse;

        public bool HasCapacityAndMemoryForGivenSoftware(SoftwareComponent software)
        {
            return this.AvailableCapacity >= software.Capacity && this.AvailableMemory >= software.Memory;
        }

        public void RegisterSoftwareComponent(SoftwareComponent component)
        {
            string componentName = component.Name;
            string componentType = component.Type;

            this.softwareComonents.Add(componentName, component);

            this.CountTypes(componentType, 1);
        }

        public void ReleaseSoftwareComponent(string componentName)
        {
            if (this.softwareComonents.ContainsKey(componentName))
            {
                var componentType = this.softwareComonents[componentName].Type;
                this.softwareComonents.Remove(componentName);

                this.CountTypes(componentType, -1);
            }
        }

        private void CountTypes(string componentType, int i)
        {
            switch (componentType)
            {
                case "Express":
                    this.ExpressSoftwareCount += i;
                    break;
                case "Light":
                    this.LigtSoftwareCount += i;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            var componentName = this.Name;
            var componentType = this.Type;
            var countOfExpressSoftwareComponents = this.ExpressSoftwareCount;
            var countOfLightSoftwareComponents = this.LigtSoftwareCount;
            var maximumMemory = this.Memory;
            var memoryUsed = this.MemoryInUse;
            var maximumCapacity = this.Capacity;
            var capacityUsed = this.CapacityInUse;
            var softwareComponentNames = string.Join(", ", this.SoftwareComponentNames);

            var output = new StringBuilder();
            output.AppendLine($"Hardware Component - {componentName}");
            output.AppendLine($"Express Software Components - {countOfExpressSoftwareComponents}");
            output.AppendLine($"Light Software Components - {countOfLightSoftwareComponents}");
            output.AppendLine($"Memory Usage: {memoryUsed} / {maximumMemory}");
            output.AppendLine($"Capacity Usage: {capacityUsed} / {maximumCapacity}");
            output.AppendLine($"Type: {componentType}");
            output.Append($"Software Components: {(softwareComponentNames == string.Empty ? "None" : softwareComponentNames)}");

            return output.ToString();
        }
    }
}
