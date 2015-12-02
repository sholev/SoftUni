namespace BankOfKurtovoKonare.Classes
{
    using System;

    using Interfaces;

    public class AccountDeposit : Account, IWithdrawable
    {
        public AccountDeposit(ICustomer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentOutOfRangeException("Insuficient funds.");
            }

            this.Balance -= amount;

            return amount;
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;

            if (this.Balance < 0 || this.Balance > 1000)
            {
                interest = this.Balance * (1 + (this.InterestRate * months));
            }

            return interest;
        }        
    }
}
