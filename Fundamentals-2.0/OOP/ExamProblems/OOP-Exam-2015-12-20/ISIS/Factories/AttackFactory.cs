namespace ISIS.Factories
{
    using ISIS.Enumerations;
    using ISIS.Exceptions;
    using ISIS.Interfaces;
    using ISIS.Models.Attacks;

    public class AttackFactory : IAttackFactory
    {
        public IAttack CreateAttack(AttackType attackType)
        {
            switch (attackType)
            {
                case AttackType.Paris:
                    return new Paris();
                case AttackType.Su24:
                    return new Su24();
                default:
                    throw new InvalidAttackTypeException($"{attackType} is not a supported attack type.");
            }
        }
    }
}
