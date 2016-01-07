namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// The Resource interface which requires the implementation
    /// of a ResourceType and Quantity properties.
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Gets the <see cref="ResourceType"/>.
        /// </summary>
        ResourceType ResourceType { get; }

        /// <summary>
        /// Gets the integer quantity.
        /// </summary>
        int Quantity { get; }
    }
}
