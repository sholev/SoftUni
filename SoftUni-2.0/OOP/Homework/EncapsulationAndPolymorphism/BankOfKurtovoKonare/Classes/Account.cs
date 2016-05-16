namespace BankOfKurtovoKonare.Classes
{
    using System;
    using Interfaces;

    public abstract class Account : IAccount, IDeposable
    {
        private ICustomer customer;
        private decimal balance;
        private decimal interestRate;

        public Account(ICustomer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public ICustomer Customer { get; set; }

        public decimal Balance { get; protected set; }

        public decimal InterestRate { get; protected set; }

        public void Deposit(decimal amount)
        {
            if (amount < 1)
            {
                throw new ArgumentOutOfRangeException("Deposit amount must not be negative or zero.");
            }

            this.Balance += amount;
        }

        public abstract decimal CalculateInterest(int months);

        public override string ToString()
        {
            return $"{Customer.Type,-10} client: {Customer.Name,-20} Interest rate: {InterestRate:F2}, current balance: {Balance:F2}.";
        }        
    }
}
