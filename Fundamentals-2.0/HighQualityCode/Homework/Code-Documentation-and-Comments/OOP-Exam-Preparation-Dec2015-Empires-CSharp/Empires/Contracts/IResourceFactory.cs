namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// The ResourceFactory interface which requires
    /// the implementation of CreateResource method.
    /// </summary>
    public interface IResourceFactory
    {
        /// <summary>
        /// Create resource method.
        /// </summary>
        /// <param name="resourceType">
        /// <see cref="ResourceType"/> parameter.
        /// </param>
        /// <param name="quantity">
        /// The quantity integer.
        /// </param>
        /// <returns>
        /// Returns <see cref="IResource"/>.
        /// </returns>
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}
