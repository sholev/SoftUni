namespace TheSlum.Items
{
    public class Pill : Bonus
    {
        private const int HealthEffectDefault = 0;
        private const int DefenseEffectDefault = 0;
        private const int AttackEffectDefault = 1000;
        private const int TimeoutTurns = 1;

        public Pill(string id) 
            : base(id, HealthEffectDefault, DefenseEffectDefault, AttackEffectDefault)
        {
            this.Timeout = TimeoutTurns;
            this.Countdown = TimeoutTurns;
        }
    }
}
