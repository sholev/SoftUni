namespace Empires.Contracts
{
    /// <summary>
    /// The Building interface which requires implementation of the
    /// <see cref="IUnitProducer"/>, <see cref="IResourceProducer"/> 
    /// and <see cref="IUpdateable"/> interfaces.
    /// </summary>
    public interface IBuilding : IUnitProducer, IResourceProducer, IUpdateable
    {
    }
}
