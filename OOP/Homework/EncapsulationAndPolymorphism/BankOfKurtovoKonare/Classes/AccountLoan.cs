namespace BankOfKurtovoKonare.Classes
{
    using static Enumerations;
    using Interfaces;

    public class AccountLoan : Account
    {
        public AccountLoan(ICustomer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;

            switch (this.Customer.Type)
            {
                case CustomerType.Individual:
                    if (months > 3)
                    {
                        interest = this.Balance * (1 + (this.InterestRate * (months - 3)));
                    }

                    break;

                case CustomerType.Corporate:
                    if (months > 2)
                    {
                        interest = this.Balance * (1 + (this.InterestRate * (months - 2)));
                    }

                    break;

                default:
                    break;
            }

            return interest;
        }
    }
}
