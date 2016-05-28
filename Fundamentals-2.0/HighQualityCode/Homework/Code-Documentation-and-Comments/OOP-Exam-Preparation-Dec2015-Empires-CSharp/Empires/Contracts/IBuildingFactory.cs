namespace Empires.Contracts
{
    /// <summary>
    /// The BuildingFactory interface which requires implementation of CreateBuilding method.
    /// </summary>
    public interface IBuildingFactory
    {
        /// <summary>
        /// Create building method.
        /// </summary>
        /// <param name="buildingType">
        /// The building type string.
        /// </param>
        /// <param name="unitFactory">
        /// The <see cref="IUnitFactory"/> used to produce units.
        /// </param>
        /// <param name="resourceFactory">
        /// The <see cref="IResourceFactory"/> used to produce resources.
        /// </param>
        /// <returns>
        /// Returns <see cref="IBuilding"/>.
        /// </returns>
        IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}
