namespace EducationSystem
{
    using EducationSystem.Core;
    using EducationSystem.Interfaces;

    public class Program
    {
        public static void Main()
        {
            IEngine engine = new UniversityEngine();
            engine.Run();
        }
    }
}