namespace ISIS.Models.WarEffects
{
    using ISIS.Interfaces;

    public class Jihad : WarEffect
    {
        public int DamageAtTrigger { get; private set; }

        public override void Trigger(IGroup affectedGroup)
        {
            base.Trigger(affectedGroup);

            this.DamageAtTrigger = affectedGroup.Damage;
            affectedGroup.Damage *= 2;
        }

        public override void TickEffect(IGroup affectedGroup)
        {
            if (affectedGroup.Damage > this.DamageAtTrigger)
            {
                affectedGroup.Damage -= 5;
            }
        }
    }
}
