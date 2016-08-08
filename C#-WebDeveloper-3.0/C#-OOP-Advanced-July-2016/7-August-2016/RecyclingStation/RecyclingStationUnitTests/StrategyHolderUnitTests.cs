namespace RecyclingStationUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Strategy;
    using RecyclingStation.WasteDisposal.Strategy.GarbageDisposalStrategy;

    [TestClass]
    public class StrategyHolderUnitTests
    {
        private StrategyHolder strategyHolder;

        [TestMethod]
        public void EmptyConstructor_InitializesStrategyHolder()
        {
            this.strategyHolder = new StrategyHolder();

            var strategies = this.strategyHolder.GetDisposalStrategies;

            Assert.IsNotNull(strategies, "Disposal stategies haven't been initialised properly.");
        }

        [TestMethod]
        public void EmptyConstructor_DoesntHaveInitialStrategies()
        {
            this.strategyHolder = new StrategyHolder();

            var strategiesCount = this.strategyHolder.GetDisposalStrategies.Count;

            Assert.AreEqual(
                strategiesCount,
                0,
                "StrategyHolder should not have strategies without adding them after initialization.");
        }

        [TestMethod]
        public void AddStrategy_SuccessfullyAddedStrategy()
        {
            this.strategyHolder = new StrategyHolder();

            var strategyType = typeof(Burnable);
            var strategy = new BurnableStrategy();

            var isAdded = this.strategyHolder.AddStrategy(strategyType, strategy);

            Assert.IsTrue(isAdded, "The srategy was not added successfully to a newly instantiated StrategyHolder");
        }

        [TestMethod]
        public void RemoveStrategy_SuccessfullyRemovedStrategy()
        {
            this.strategyHolder = new StrategyHolder();

            var strategyType = typeof(Burnable);
            var strategy = new BurnableStrategy();

            this.strategyHolder.AddStrategy(strategyType, strategy);
            var isRemoved = this.strategyHolder.RemoveStrategy(strategyType);

            Assert.IsTrue(isRemoved, "The strategy was not successfully removed from the StrategyHolder");
        }

        [TestMethod]
        public void AddStrategy_UnableToAddStrategy()
        {
            this.strategyHolder = new StrategyHolder();

            var strategyType = typeof(Burnable);
            var strategy = new BurnableStrategy();

            this.strategyHolder.AddStrategy(strategyType, strategy);
            var isAdded = this.strategyHolder.AddStrategy(strategyType, strategy);

            Assert.IsFalse(isAdded, "The srategy should not be added twice to a StrategyHolder");
        }

        [TestMethod]
        public void RemoveStrategy_UnableToRemoveStrategy()
        {
            this.strategyHolder = new StrategyHolder();

            var strategyType = typeof(Burnable);
            
            var isRemoved = this.strategyHolder.RemoveStrategy(strategyType);

            Assert.IsFalse(isRemoved, "THe StrategyHolder should not report successful removal of unexisting strategies.");
        }
    }
}