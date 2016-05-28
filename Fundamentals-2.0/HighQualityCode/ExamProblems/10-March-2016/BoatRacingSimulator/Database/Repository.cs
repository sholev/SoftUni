namespace BoatRacingSimulator.Database
{
    using System.Collections.Generic;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    public class Repository<T> : IRepository<T> where T : IModel
    {
        public Repository()
        {
            this.ItemsByModel = new Dictionary<string, T>();
        }

        private Dictionary<string, T> ItemsByModel { get; set; }

        public void Add(T item)
        {
            if (this.ItemsByModel.ContainsKey(item.Model))
            {
                throw new DuplicateModelException(Constants.DuplicateModelMessage);
            }

            this.ItemsByModel.Add(item.Model, item);
        }

        public T GetItem(string model)
        {
            if (!this.ItemsByModel.ContainsKey(model))
            {
                throw new NonExistantModelException(Constants.NonExistantModelMessage);
            }

            return this.ItemsByModel[model];
        }
    }
}
