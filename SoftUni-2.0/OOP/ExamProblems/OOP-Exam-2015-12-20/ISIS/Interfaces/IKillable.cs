namespace ISIS.Interfaces
{
    public interface IKillable
    {
        int HealthPoints { get; set; }

        void TakeDamage(int damage);
    }
}
