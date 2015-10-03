using System.IO;
using System.Collections.Generic;
using System.Linq;

class FullDirectoryTraversal
{
    static void Main()
    {
        // Clean up if file exists.
        if (File.Exists(@"..\..\output.txt"))
        {
            File.Delete(@"..\..\output.txt");
        }

        PrintDirectoryFiles(@"..\..\");
    }

    // My recursive modification of DirectoryTraversal by E.Bojilova
    private static void PrintDirectoryFiles(string currentDirectory)
    {
        string[] filePaths = Directory.GetFiles(currentDirectory);

        List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList(); // K.Marincheva

        var sortedExtensionsAndFileInfos = files.OrderBy(file => file.Length)
                                                .GroupBy(file => file.Extension)
                                                .OrderByDescending(group => group.Count())
                                                .ThenBy(group => group.Key);

        string ouputPath = @"..\..\output.txt";        

        using (StreamWriter writer = new StreamWriter(ouputPath, true)) // true in order to append, not rewrite.
        {
            writer.WriteLine("\r\n\\bin\\Debug{0}:", currentDirectory);
            foreach (var extensionGroup in sortedExtensionsAndFileInfos)
            {
                writer.WriteLine(extensionGroup.Key);
                foreach (var fileInfo in extensionGroup)
                {
                    writer.WriteLine("--{0} - {1:F3}kb", fileInfo.Name, fileInfo.Length / 1024.0);
                }
            }
        }

        // Recursion:
        string[] directories = Directory.GetDirectories(currentDirectory);
        foreach (var directory in directories)
        {
            PrintDirectoryFiles(directory);
        }
    }
}