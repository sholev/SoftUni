namespace BoatRacingSimulator.Interfaces
{
    public interface IBoat : IModel
    {
        double CalculateRaceSpeed(IRace race);
    }
}