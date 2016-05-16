namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        private const int HealthEffectDefault = 200;
        private const int DefenseEffectDefault = 0;
        private const int AttackEffectDefault = 0;
        private const int TimeoutTurns = 3;

        public Injection(string id) 
            : base(id, HealthEffectDefault, DefenseEffectDefault, AttackEffectDefault)
        {
            this.Timeout = TimeoutTurns;
            this.Countdown = TimeoutTurns;
        }
    }
}
