namespace BankOfKurtovoKonare.Interfaces
{
    using static Classes.Enumerations;

    public interface ICustomer
    {
        string Name { get; set; }

        CustomerType Type { get; set; }
    }
}
