namespace AC_TestingSystem.Interfaces
{
    /// <summary>
    /// A report showing if the test was passed or not.
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// The manufacturer of the air conditioner for which is the report.
        /// </summary>
        string Manufacturer { get; }

        /// <summary>
        /// The result of the test, does it fail (0) or not (1).
        /// </summary>
        int Mark { get; }

        /// <summary>
        /// The Model of the air conditionerfor which is the report.
        /// </summary>
        string Model { get; }
    }
}