namespace ThereBeLab
{
    class Startup
    {
        static void Main(string[] args)
        {
            StudentsRepository.InitializeData();
            StudentsRepository.GetAllStudentsFromCourse("Unity");
            //IOManager.TraverseDirectory("../../../");
        }
    }
}
