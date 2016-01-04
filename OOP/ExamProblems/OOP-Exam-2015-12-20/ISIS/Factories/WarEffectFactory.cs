namespace ISIS.Factories
{
    using ISIS.Enumerations;
    using ISIS.Exceptions;
    using ISIS.Interfaces;
    using ISIS.Models.WarEffects;

    public class WarEffectFactory : IWarEffectFactory
    {
        public IWarEffect CreateWarEffect(WarEffects warEffect)
        {
            switch (warEffect)
            {
                case WarEffects.Jihad:
                    return new Jihad();
                case WarEffects.Kamikaze:
                    return new Kamikaze();
                default:
                    throw new InvalidWarEffectException($"{warEffect} is not a supported war effect.");
            }
        }
    }
}
