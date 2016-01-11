namespace CohesionAndCoupling
{
    using System;

    public class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException($"{nameof(fileName)}:{fileName} is invalid.");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
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
