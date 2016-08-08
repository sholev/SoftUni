namespace RecyclingStation.WasteDisposal.Strategy
{
    using System;
    using System.Collections.Generic;

    using RecyclingStation.WasteDisposal.Interfaces;

    public class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies
            => this.strategies as IReadOnlyDictionary<Type, IGarbageDisposalStrategy>;

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (!this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Add(disposableAttribute, strategy);

                return true;
            }

            return false;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Remove(disposableAttribute);

                return true;
            }
            
            return false;
        }
    }
}