namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The model implementing this interface should
    /// hold all the necessary information about a race.
    /// </summary>
    public interface IRace
    {
        /// <summary>
        /// The distance from the begining to the end of the race.
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// The wind speed condition during the race.
        /// </summary>
        int WindSpeed { get; }
        
        /// <summary>
        /// The ocean current condition during the race.
        /// </summary>
        int OceanCurrentSpeed { get; }

        /// <summary>
        /// Are motorboats allowed in the race.
        /// </summary>
        bool AllowsMotorboats { get; }

        /// <summary>
        /// Add a participant <see cref="IBoat"/> to the race.
        /// </summary>
        /// <param name="boat">The <see cref="IBoat"/> participating in the race. </param>
        void AddParticipant(IBoat boat);

        /// <summary>
        /// Get a list of all participants added to the race.
        /// </summary>
        /// <returns>Returns an <see cref="IList{T}"/> of <see cref="IBoat"/>.</returns>
        IList<IBoat> GetParticipants();
    }
}
