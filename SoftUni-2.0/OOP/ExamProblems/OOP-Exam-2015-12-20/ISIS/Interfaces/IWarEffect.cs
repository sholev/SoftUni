namespace ISIS.Interfaces
{
    public interface IWarEffect
    {
        void Trigger(IGroup affectedGroup);

        void TickEffect(IGroup affectedGroup);
    }
}
