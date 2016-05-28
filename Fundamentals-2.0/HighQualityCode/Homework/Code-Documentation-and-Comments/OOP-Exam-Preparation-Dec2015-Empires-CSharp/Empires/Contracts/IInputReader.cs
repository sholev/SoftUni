namespace Empires.Contracts
{
    /// <summary>
    /// The InputReader interface which requires
    /// the implementation of the ReadLine method.
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// The read line method.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="string"/>.
        /// </returns>
        string ReadLine();
    }
}
