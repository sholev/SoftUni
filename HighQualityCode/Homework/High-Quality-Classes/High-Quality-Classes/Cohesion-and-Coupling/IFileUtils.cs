namespace CohesionAndCoupling
{
    public interface IFileUtils
    {
        string GetFileExtension(string fileName);

        string GetFileNameWithoutExtension(string fileName);
    }
}