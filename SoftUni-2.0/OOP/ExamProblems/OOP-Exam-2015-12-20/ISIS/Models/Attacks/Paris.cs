namespace ISIS.Models.Attacks
{
    using ISIS.Interfaces;

    public class Paris : IAttack
    {
        public void AttackTargetGroup(IGroup attacker, IGroup target)
        {
            target.TakeDamage(attacker.Damage);
        }
    }
}
