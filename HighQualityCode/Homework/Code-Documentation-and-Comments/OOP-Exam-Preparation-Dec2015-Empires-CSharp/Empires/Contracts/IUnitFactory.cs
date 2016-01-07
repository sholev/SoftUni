namespace Empires.Contracts
{
    /// <summary>
    /// The UnitFactory interface which requires the
    /// implementation of the CreateUnit method.
    /// </summary>
    public interface IUnitFactory
    {
        /// <summary>
        /// Create a unit.
        /// </summary>
        /// <param name="unitType">
        /// The unit type string.
        /// </param>
        /// <returns>
        /// Returns <see cref="IUnit"/>.
        /// </returns>
        IUnit CreateUnit(string unitType);
    }
}
