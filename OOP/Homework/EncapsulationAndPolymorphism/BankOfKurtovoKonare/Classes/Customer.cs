namespace BankOfKurtovoKonare.Classes
{
    using System;

    using static Enumerations;
    using Interfaces;

    public class Customer : ICustomer
    {
        private string name;

        public Customer(string name, CustomerType type)
        {
            this.Name = name;
            this.Type = type;
        }
        
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Customer name cannot be empty.");
                }

                this.name = value;
            }
        }

        public CustomerType Type { get; set; }
    }
}
