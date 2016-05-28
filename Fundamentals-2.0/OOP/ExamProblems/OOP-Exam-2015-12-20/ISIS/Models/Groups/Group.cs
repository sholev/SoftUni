namespace ISIS.Models.Groups
{
    using ISIS.Interfaces;

    public class Group : IGroup
    {
        public Group(string name, int healthPoints, int damage, IAttack attack, IWarEffect warEffect)
        {
            this.Name = name;
            this.StartingHealthPoints = healthPoints;
            this.HealthPoints = healthPoints;
            this.Damage = damage;
            this.Attack = attack;
            this.WarEffect = warEffect;
        }

        public string Name { get; set; }

        public int HealthPoints { get; set; }

        public int Damage { get; set; }

        private IAttack Attack { get; }
        
        private IWarEffect WarEffect { get; }

        private bool WarEffectTriggered { get; set; }

        private int StartingHealthPoints { get; }

        public void AttackTarget(IGroup target)
        {
            this.Attack.AttackTargetGroup(this, target);
        }

        public void IncrementDays()
        {
            if (this.WarEffectTriggered)
            {
                this.WarEffect.TickEffect(this);
            }
        }

        public void TakeDamage(int damage)
        {

            this.HealthPoints -= damage;

            if (!this.WarEffectTriggered && this.HealthPoints < this.StartingHealthPoints / 2)
            {
                this.WarEffectTriggered = true;
                this.TriggerWarEffect();
            }
        }

        private void TriggerWarEffect()
        {
            this.WarEffect.Trigger(this);
        }

        public override string ToString()
        {
            return this.HealthPoints > 0 
                ? $"Group {this.Name}: {this.HealthPoints} HP, {this.Damage} Damage" 
                : $"Group {this.Name} AMEN";
        }
    }
}
