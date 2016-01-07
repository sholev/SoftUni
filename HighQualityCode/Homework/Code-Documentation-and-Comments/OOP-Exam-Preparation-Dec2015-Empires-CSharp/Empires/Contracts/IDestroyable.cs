namespace Empires.Contracts
{
    /// <summary>
    /// Requires implementation of the Health property.
    /// </summary>
    public interface IDestroyable
    {
        /// <summary>
        /// Gets or sets the health integer.
        /// </summary>
        int Health { get; set; }
    }
}
