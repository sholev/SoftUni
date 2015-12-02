namespace TheSlum.Items
{
    public class Axe : Item
    {
        private const int HealthEffectDefault = 0;
        private const int DefenseEffectDefault = 0;
        private const int AttackEffectDefault = 75;

        public Axe(string id) 
            : base(id, HealthEffectDefault, DefenseEffectDefault, AttackEffectDefault)
        {
        }
    }
}
