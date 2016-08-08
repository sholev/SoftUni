namespace RecyclingStation.WasteDisposal.Strategy
{
    using System;
    using System.Linq;
    using System.Reflection;

    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public GarbageProcessor()
        {
            this.StrategyHolder = new StrategyHolder();

            var strategyAttributes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.FullName.Contains("Attributes"));

            var garbageDisposalStrategies = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.FullName.Contains("GarbageDisposalStrategy"))
                .ToArray();

            foreach (Type strategyAttribute in strategyAttributes)
            {
                var strategyName = strategyAttribute.Name;

                var garbageDisposalStrategy =
                    garbageDisposalStrategies.FirstOrDefault(s => s.FullName.Contains(strategyName));

                if (garbageDisposalStrategy != null)
                {
                    this.StrategyHolder.AddStrategy(
                        strategyAttribute,
                        Activator.CreateInstance(garbageDisposalStrategy) as IGarbageDisposalStrategy);
                }
            }
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            var type = garbage.GetType();
            var disposalAttribute = type.GetCustomAttributes(true).FirstOrDefault() as DisposableAttribute;
            IGarbageDisposalStrategy currentStrategy;
            if (disposalAttribute == null || 
                !this.StrategyHolder.GetDisposalStrategies.TryGetValue(disposalAttribute.GetType(), out currentStrategy))
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}
