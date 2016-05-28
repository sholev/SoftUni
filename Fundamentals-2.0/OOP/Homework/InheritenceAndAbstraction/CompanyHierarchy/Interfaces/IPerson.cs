namespace CompanyHierarchy.Interfaces
{
    public interface IPerson
    {
        uint Id { get; set; }

        string Name { get; set; }

        string Surname { get; set; }
    }
}