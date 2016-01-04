namespace ISIS.Interfaces
{
    using ISIS.Enumerations;

    public interface IAttackFactory
    {
        IAttack CreateAttack(AttackType attackType);
    }
}