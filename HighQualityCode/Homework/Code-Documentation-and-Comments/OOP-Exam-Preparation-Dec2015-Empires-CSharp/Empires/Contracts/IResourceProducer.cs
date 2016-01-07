namespace Empires.Contracts
{
    using Models.EventHandlers;

    /// <summary>
    /// The ResourceProducer interface which requires
    /// implementation of the OnResourceProduced event.
    /// </summary>
    public interface IResourceProducer
    {
        /// <summary>
        /// The on resource produced event. <see cref="ResourceProducedEventHandler"/>
        /// </summary>
        event ResourceProducedEventHandler OnResourceProduced;
    }
}
