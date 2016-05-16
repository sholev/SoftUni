namespace ISIS.Models.Attacks
{
    using ISIS.Interfaces;

    public class Su24 : IAttack
    {
        public void AttackTargetGroup(IGroup attacker, IGroup target)
        {
            int halfHealthDamage = attacker.HealthPoints / 2;
            attacker.TakeDamage(halfHealthDamage);

            if (attacker.HealthPoints < 1)
            {
                attacker.HealthPoints = 1;
            }

            int doubledAttackerDamage = attacker.Damage * 2;
            target.TakeDamage(doubledAttackerDamage);
        }
    }
}
