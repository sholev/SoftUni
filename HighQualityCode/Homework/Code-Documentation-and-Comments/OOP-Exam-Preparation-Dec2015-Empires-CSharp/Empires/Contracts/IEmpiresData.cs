namespace Empires.Contracts
{
    using System.Collections.Generic;

    using Enums;

    /// <summary>
    /// The empire data interface.
    /// </summary>
    public interface IEmpiresData
    {
        /// <summary>
        /// Gets the <see cref="IBuilding"/>.
        /// </summary>
        IEnumerable<IBuilding> Buildings { get; }

        /// <summary>
        /// Gets the unit string and tis quantity.
        /// </summary>
        IDictionary<string, int> Units { get; }

        /// <summary>
        /// Gets the <see cref="ResourceType"/> and its quantity.
        /// </summary>
        IDictionary<ResourceType, int> Resources { get; }

        /// <summary>
        /// Add building.
        /// </summary>
        /// <param name="building">
        /// The <see cref="Empires.Models.Buildings.Building"/> which should be added.
        /// </param>
        void AddBuilding(IBuilding building);

        /// <summary>
        /// Add unit.
        /// </summary>
        /// <param name="unit">
        /// The <see cref="IUnit"/> which should be added.
        /// </param>
        void AddUnit(IUnit unit);
    }
}
