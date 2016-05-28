namespace ISIS.Factories
{
    using ISIS.Enumerations;
    using ISIS.Interfaces;
    using ISIS.Models.Groups;

    public class GroupFactory : IGroupFactory
    {
        public GroupFactory(IWarEffectFactory warEffectFactory, IAttackFactory attackFactory)
        {
            this.WarEffectFactory = warEffectFactory;
            this.AttackFactory = attackFactory;
        }

        private IWarEffectFactory WarEffectFactory { get; }

        private IAttackFactory AttackFactory { get; }

        public IGroup CreateGroup(string name, int health, int damage, WarEffects warEffect, AttackType attack)
        {
            IWarEffect groupWarEffect = this.WarEffectFactory.CreateWarEffect(warEffect);
            IAttack groupAttack = this.AttackFactory.CreateAttack(attack);
            IGroup group = new Group(name, health, damage, groupAttack, groupWarEffect);

            return group;
        }
    }
}
