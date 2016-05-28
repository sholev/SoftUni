namespace CompanyHierarchy.Models.Sale
{
    using System;

    using global::CompanyHierarchy.Interfaces;

    internal class Sale : ISale
    {
        private string productName;
        private decimal price;

        public DateTime Date { get; set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("Sale price cannot be negative");
                }
                this.price = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product name should not be null or empty");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name should not be null or whitespace");
                }
                this.productName = value;
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
            return $"Product sold: {this.ProductName,-15}, Date: {this.Date.Date}, Price: {this.Price}";
        }
    }
}
