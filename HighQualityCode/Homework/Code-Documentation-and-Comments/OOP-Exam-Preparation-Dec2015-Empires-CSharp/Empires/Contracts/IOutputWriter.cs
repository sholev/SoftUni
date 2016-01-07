namespace Empires.Contracts
{
    /// <summary>
    /// The OutputWriter interface which requires
    /// the implementation of a Print method.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// The print output method.
        /// </summary>
        /// <param name="message">
        /// The string message output.
        /// </param>
        void Print(string message);
    }
}
