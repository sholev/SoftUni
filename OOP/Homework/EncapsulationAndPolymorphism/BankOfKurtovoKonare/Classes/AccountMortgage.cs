namespace BankOfKurtovoKonare.Classes
{
    using static Enumerations;
    using Interfaces;

    public class AccountMortgage : Account
    {
        public AccountMortgage(ICustomer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            decimal interest = 0;

            switch (this.Customer.Type)
            {
                case CustomerType.Individual:
                    if (months > 6)
                    {
                        interest = this.Balance * (1 + (this.InterestRate * (months - 6)));
                    }

                    break;

                case CustomerType.Corporate:
                    interest = (this.Balance * (1 + (this.InterestRate * months))) / 2;
                    if (months > 12)
                    {
                        interest += this.Balance * (1 + (this.InterestRate * (months - 12)));
                    }

                    break;

                default:
                    break;
            }

            return interest;
        }
    }
}
