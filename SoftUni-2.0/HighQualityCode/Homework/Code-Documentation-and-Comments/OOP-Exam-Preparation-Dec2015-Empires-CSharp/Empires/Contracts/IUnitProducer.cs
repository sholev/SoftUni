namespace Empires.Contracts
{
    using Models.EventHandlers;

    /// <summary>
    /// The UnitProducer interface which requires
    /// implementation of the OnUnitProduced event.
    /// </summary>
    public interface IUnitProducer
    {
        /// <summary>
        /// The on unit produced event. <see cref="UnitProducedEventHandler"/>
        /// </summary>
        event UnitProducedEventHandler OnUnitProduced;
    }
}
