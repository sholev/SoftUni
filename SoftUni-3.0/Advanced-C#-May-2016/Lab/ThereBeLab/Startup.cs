namespace ThereBeLab
{
    using System.Diagnostics;

    using ThereBeLab.IO;

    class Startup
    {
        static void Main(string[] args)
        {
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");
            IOManager.TraverseDirectory(SessionData.CurrentPath);
            //Tester.CompareContent(@"Resources\test2.txt", @"Resources\test3.txt");
            //var path = IOManager.CreateDirectoryInCurrentFolder("pesho");
            //Process.Start(path);

        }
    }
}
