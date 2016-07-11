namespace SystemSplit.Models.Software
{
    public abstract class SoftwareComponent : Component
    {
        private string type;

        protected SoftwareComponent(string name, string type, long capacityConsumption, long memoryConsuption)
            : base(name, capacityConsumption, memoryConsuption)
        {
            this.type = type;
        }

        public string Type => this.type;
    }
}
