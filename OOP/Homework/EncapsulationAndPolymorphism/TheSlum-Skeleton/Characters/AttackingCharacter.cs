namespace TheSlum.Characters
{
    using Interfaces;

    public abstract class AttackingCharacter : AdvancedCharacter, IAttack
    {
        public AttackingCharacter(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
        }

        public int AttackPoints { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", Attack: " + this.AttackPoints;
        }

        public override void RemoveFromInventory(Item item)
        {
            base.RemoveFromInventory(item);
            this.AttackPoints -= item.AttackEffect;
        }

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }
    }
}
