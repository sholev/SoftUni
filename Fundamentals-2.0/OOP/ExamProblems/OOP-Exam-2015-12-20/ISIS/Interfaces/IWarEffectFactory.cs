namespace ISIS.Interfaces
{
    using ISIS.Enumerations;

    public interface IWarEffectFactory
    {
        IWarEffect CreateWarEffect(WarEffects warEffect);
    }
}