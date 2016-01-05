namespace CompanyHierarchy.Interfaces
{
    using global::CompanyHierarchy.Enumerations;

    public interface IEmployee : IPerson
    {
        Department Department { get; set; }

        decimal Salary { get; set; }
    }


}
