namespace SystemSplit.Models
{
    public abstract class Component
    {
        protected Component(string name,  long capacity, long memory)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Memory = memory;
        }

        public virtual string Name { get; }

        public virtual long Capacity { get; }

        public virtual long Memory { get; }
    }
}
