namespace Empires.Contracts
{
    /// <summary>
    /// The Unit interface which requires the implementation of the
    /// <see cref="IAttacker"/> and <see cref="IDestroyable"/> interfaces.
    /// </summary>
    public interface IUnit : IAttacker, IDestroyable
    {
    }
}
