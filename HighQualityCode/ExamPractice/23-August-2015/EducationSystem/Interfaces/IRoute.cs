namespace EducationSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// A Route is used to process the input and take out
    /// of it the parts needed for the Controller and View.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// The name of the controller, 
        /// which will process the input.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// The name of the action, which
        /// will be the method in the controller.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Additional input parameters that
        /// the method will require.
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}