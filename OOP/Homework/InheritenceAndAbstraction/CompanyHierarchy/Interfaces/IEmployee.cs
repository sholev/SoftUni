namespace CompanyHierarchy.Interfaces
{
    enum Department
    {
        PRODUCTION,
        ACCOUNTING,
        SALES,
        MARKETING
    }

    interface IEmployee : IPerson
    {
        Department Department { get; set; }
        decimal Salary { get; set; }
    }


}
