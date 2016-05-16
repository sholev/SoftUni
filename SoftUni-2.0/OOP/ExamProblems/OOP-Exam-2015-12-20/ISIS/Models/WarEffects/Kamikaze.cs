namespace ISIS.Models.WarEffects
{
    using ISIS.Interfaces;

    public class Kamikaze : WarEffect
    {
        public override void Trigger(IGroup affectedGroup)
        {
            base.Trigger(affectedGroup);

            int bonusHealth = 40;

            affectedGroup.HealthPoints += bonusHealth;
        }

        public override void TickEffect(IGroup affectedGroup)
        {
            int damagePerTick = 10;

            affectedGroup.TakeDamage(damagePerTick);
        }
    }
}
