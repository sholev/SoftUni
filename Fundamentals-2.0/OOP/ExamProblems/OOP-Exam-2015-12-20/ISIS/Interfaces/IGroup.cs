namespace ISIS.Interfaces
{
    public interface IGroup : IKillable, IAttacker, ITimeIsSlippingAway
    {
        string Name { get; set; }
    }
}
