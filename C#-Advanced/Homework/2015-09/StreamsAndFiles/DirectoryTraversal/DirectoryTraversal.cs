using System.IO;
using System.Collections.Generic;
using System.Linq;

// original by E.Bojilova

class DirectoryTraversal
{
    static void Main()
    { 
        string[] filePaths = Directory.GetFiles(@"..\..\");
        
        List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList(); // K.Marincheva

        var sortedExtensionsAndFileInfos = files.OrderBy(file => file.Length)
                                                .GroupBy(file => file.Extension)
                                                .OrderByDescending(group => group.Count())
                                                .ThenBy(group => group.Key);

        string ouputPath = @"..\..\output.txt";

        using (StreamWriter writer = new StreamWriter(ouputPath, false))
        {
            foreach (var extensionGroup in sortedExtensionsAndFileInfos)
            {
                writer.WriteLine(extensionGroup.Key);
                foreach (var fileInfo in extensionGroup)
                {
                    writer.WriteLine("--{0} - {1:F3}kb", fileInfo.Name, fileInfo.Length / 1024.0);
                }
            }
        }
    }
}
