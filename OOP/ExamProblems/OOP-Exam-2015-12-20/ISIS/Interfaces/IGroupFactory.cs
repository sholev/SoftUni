namespace ISIS.Interfaces
{
    using ISIS.Enumerations;

    public interface IGroupFactory
    {
        IGroup CreateGroup(string name, int health, int damage, WarEffects warEffect, AttackType attack);
    }
}
