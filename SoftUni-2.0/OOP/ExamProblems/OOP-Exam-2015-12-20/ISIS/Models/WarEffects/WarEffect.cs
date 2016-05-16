namespace ISIS.Models.WarEffects
{
    using ISIS.Exceptions;

    using ISIS.Interfaces;

    public abstract class WarEffect : IWarEffect
    {
        protected bool Triggered { get; set; }

        public virtual void Trigger(IGroup affectedGroup)
        {
            if (!this.Triggered)
            {
                this.Triggered = true;
            }
            else
            {
                throw new EffectException($"{this.GetType()} effect was already triggered.");
            }
        }

        public abstract void TickEffect(IGroup affectedGroup);
    }
}
