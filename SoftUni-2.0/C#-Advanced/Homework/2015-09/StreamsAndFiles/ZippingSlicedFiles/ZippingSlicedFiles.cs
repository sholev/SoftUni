using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Threading;

class ZippingSlicedFiles
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

        slicedFile = Slice(sourceFile, destinationDirectory, splitSize);
        Assemble(slicedFile, destinationDirectory, "Assembled.mp4");
    }

    // Maybe I should try to improve the slicing using this as an example. Less code. :D
    // http://stackoverflow.com/questions/14524909/combine-multiple-files-into-single-file
    private static void Assemble(List<string> slicedFile, string destinationDirectory, string destFile)
    {
        using (var outputStream = File.Create(destinationDirectory + "\\" + destFile))
        {
            foreach (string filePath in slicedFile)
            {
                using (var sourceStream = File.OpenRead(destinationDirectory + "\\" + filePath))
                {
                    // Just added GZipStream here.
                    using (GZipStream decompressOutput = new GZipStream(sourceStream, CompressionMode.Decompress, false))
                    {
                        // Using the GZipStream instead of outputStream.
                        decompressOutput.CopyTo(outputStream); // You can pass the buffer size as second argument.
                    }
                }

                Thread.Sleep(100); // wait a bit to avoid maxing out disk IO.
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
                using (Stream output = File.Create(destinationDirectory + "\\Part-" + (index + 1) + ".gz"))
                {
                    // Just added GZipStream here.
                    using (GZipStream compressOutput = new GZipStream(output, CompressionMode.Compress, false))
                    {
                        int remaining = parts, bytesRead;
                        while (remaining > 0 && (bytesRead = input.Read(buffer, 0,
                                Math.Min(remaining, BUFFER_SIZE))) > 0)
                        {
                            // Using the GZipStream instead of output stream.
                            compressOutput.Write(buffer, 0, bytesRead);
                            remaining -= bytesRead;
                        }
                    }                    
                }

                index++;
                fileNames.Add("Part-" + index + ".gz");

                Thread.Sleep(100); // wait a bit to avoid maxing out disk IO.
            }
        }

        return fileNames;
    }
}
