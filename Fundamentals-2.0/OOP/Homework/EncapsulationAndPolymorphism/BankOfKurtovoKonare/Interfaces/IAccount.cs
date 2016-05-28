namespace BankOfKurtovoKonare.Interfaces
{
    public interface IAccount
    {
        ICustomer Customer { get; set; }

        decimal Balance { get; }

        decimal InterestRate { get; }

        decimal CalculateInterest(int months);
    }
}
