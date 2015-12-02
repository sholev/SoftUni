namespace CompanyHierarchy.Interfaces
{
    interface ICustomer : IPerson
    {
        decimal NetPurchaseAmount { get; set; }
    }
}
