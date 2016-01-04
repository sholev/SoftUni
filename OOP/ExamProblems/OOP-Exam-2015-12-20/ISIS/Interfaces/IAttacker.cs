namespace ISIS.Interfaces
{
    public interface IAttacker
    {
        int Damage { get; set; }

        void AttackTarget(IGroup target);
    }
}
