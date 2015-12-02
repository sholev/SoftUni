using System;
using System.Collections.Generic;
using System.Linq;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Classes.Person.Customer
{
    class Customer : Person, ICustomer
    {
        decimal netPurchaseAmount;

        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentException("The net purchase amount cannot be negative.");
                }
                this.netPurchaseAmount = value;
            }
        }

        public Customer(uint id, string name, string surname, decimal netPurchaseAmount)
            : base(id, name, surname)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Net purchase amount: {NetPurchaseAmount}";
        }
    }
}
