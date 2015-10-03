using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

class SlicingFile
{
    static void Main()
    {
        string sourceFile = @"sliceThis.mp4";
        string destinationDirectory = @"..\..\..\";

        // Get the file size based on how many times we split it.
        FileInfo file = new FileInfo(destinationDirectory + sourceFile);
        int parts = 5;
        int splitSize = (int)(file.Length / parts + 1);

        // This is where we store the sliced file names.
        List<string> slicedFile = new List<string>();

        slicedFile = Slice(sourceFile, destinationDirectory, parts);
        Assemble(slicedFile, destinationDirectory, "Assembled.mp4");
    }

    // http://stackoverflow.com/questions/14524909/combine-multiple-files-into-single-file
    private static void Assemble(List<string> slicedFile, string destinationDirectory, string destFile)
    {        
        using (var destStream = File.Create(destinationDirectory + "\\" + destFile))
        {
            foreach (string filePath in slicedFile)
            {
                using (var sourceStream = File.OpenRead(destinationDirectory + "\\" + filePath))
                {
                    sourceStream.CopyTo(destStream); // You can pass the buffer size as second argument.
                }
                Thread.Sleep(100);
            }
        }
    }

    // http://stackoverflow.com/questions/3967541/how-to-split-large-files-efficiently
    private static List<string> Slice(string sourceFile, string destinationDirectory, int parts)
    {
        List<string> fileNames = new List<string>();
        const int BUFFER_SIZE = 20 * 1024;
        byte[] buffer = new byte[BUFFER_SIZE];

        using (Stream input = File.OpenRead(destinationDirectory + "\\" + sourceFile))
        {
            int index = 0;
            while (input.Position < input.Length)
            {
                using (Stream output = File.Create(destinationDirectory + "\\Sliced.part" + (index + 1)))
                {
                    int remaining = parts, bytesRead;
                    while (remaining > 0 && (bytesRead = input.Read(buffer, 0,
                            Math.Min(remaining, BUFFER_SIZE))) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                        remaining -= bytesRead;
                    }
                }
                index++;
                fileNames.Add("Sliced.part" + index);
                Thread.Sleep(100); // experimental; perhaps try it
            }
        }

        return fileNames;
    }
//    // My attempt, albeit failing.
//    private static List<string> Slice(string sourceFile, string destinationDirectory, int parts)
//    {
//        byte[] fileBytes = File.ReadAllBytes($"{destinationDirectory}\\{sourceFile}");
//        List<string> fileNames = new List<string>();

//        for (int i = 0, fileNumber = 0; i < fileBytes.Length; i += fileBytes.Length / parts, fileNumber++ )
//        {
//            try
//            {
//                File.WriteAllBytes($"{destinationDirectory}\\Split.file{fileNumber}",
//                fileBytes.Skip(i).Take(i + fileBytes.Length / parts).ToArray());
//                fileNames.Add($"Split.file{fileNumber}");
//            }
//            catch (Exception)
//            {
//                File.WriteAllBytes($"{destinationDirectory}\\Split.file{fileNumber}",
//                fileBytes.Skip(i).Take(fileBytes.Length - 1 - i).ToArray());
//                fileNames.Add($"Split.file{fileNumber}");
//            }
//        }
//        return fileNames;
//    }
}