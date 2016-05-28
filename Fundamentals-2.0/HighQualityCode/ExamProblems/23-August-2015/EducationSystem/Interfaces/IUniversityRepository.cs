namespace EducationSystem.Interfaces
{
    using EducationSystem.Data;
    using EducationSystem.Model;

    public interface IUniversityRepository
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}