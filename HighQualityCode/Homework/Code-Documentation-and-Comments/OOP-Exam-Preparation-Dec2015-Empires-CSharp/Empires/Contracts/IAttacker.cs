namespace Empires.Contracts
{
    /// <summary>
    /// The Attacker interface requires 
    /// the availability of a AttackDamage property.
    /// </summary>
    public interface IAttacker
    {
        /// <summary>
        /// Gets the attack damage integer of the IAttacker.
        /// </summary>
        int AttackDamage { get; }
    }
}
