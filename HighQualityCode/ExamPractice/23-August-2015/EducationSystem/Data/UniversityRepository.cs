namespace EducationSystem.Data
{
    using EducationSystem.Interfaces;
    using EducationSystem.Model;

    public class UniversityRepository : IUniversityRepository
    {
        public UniversityRepository()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; }

        public IRepository<Course> Courses { get; }
    }
}
