namespace CohesionAndCoupling
{
    using System;

    public class FileUtils : IFileUtils
    {
        public string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException($"{nameof(fileName)}:{fileName} is invalid.");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException($"{nameof(fileName)}:{fileName} is invalid.");
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
