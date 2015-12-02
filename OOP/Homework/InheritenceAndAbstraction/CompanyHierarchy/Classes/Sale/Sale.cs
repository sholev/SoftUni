using System;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Classes.Sale
{
    class Sale : ISale
    {
        private string productName;
        private decimal price;
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("Sale price cannot be negative");
                }
                price = value;
            }
        }

        public string ProductName
        {
            get { return productName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product name should not be null or empty");
                }
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name should not be null or whitespace");
                }
                productName = value;
            }
        }

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"Product sold: {ProductName,-15}, Date: {Date.Date}, Price: {Price}";
        }
    }
}
