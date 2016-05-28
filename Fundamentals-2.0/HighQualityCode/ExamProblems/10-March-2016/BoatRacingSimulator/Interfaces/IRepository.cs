namespace BoatRacingSimulator.Interfaces
{
    public interface IRepository<T> where T : IModel
    {
        void Add(T item);

        T GetItem(string model);
    }
}
