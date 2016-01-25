namespace Theaters.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Theaters.Business;

    /// <summary>
    /// The PerformanceDatabase interface.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Add a theater to the database.
        /// </summary>
        /// <param name="theaterName">
        /// A string containing the theater name.
        /// </param>
        void AddTheater(string theaterName);
        
        /// <summary>
        /// List all theaters.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="IEnumerable"/> of strings 
        /// containing the names of all theaters.
        /// </returns>
        IEnumerable<string> ListTheaters();

        /// <summary>
        /// Add a new performance to a theater 
        /// in the performance database.
        /// </summary>
        /// <param name="theaterName">
        /// The name of the theater to which 
        /// the performance will be added.
        /// </param>
        /// <param name="performanceTitle">
        /// The performance title.
        /// </param>
        /// <param name="startDateTime">
        /// The start <see cref="DateTime"/> 
        /// of the performance.
        /// </param>
        /// <param name="duration">
        /// The duration <see cref="TimeSpan"/> 
        /// of the performance.
        /// </param>
        /// <param name="price">
        /// The price of the performance.
        /// </param>
        void AddPerformance(string theaterName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Get a list of all performances.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable"/> of 
        /// <see cref="Performance"/>.
        /// </returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// List all performances in a theater.
        /// </summary>
        /// <param name="theaterName">
        /// The name of the theater where 
        /// the performances will be held.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable"/> of 
        /// <see cref="Performance"/>.
        /// </returns>
        IEnumerable<Performance> ListPerformances(string theaterName);
    }
}
