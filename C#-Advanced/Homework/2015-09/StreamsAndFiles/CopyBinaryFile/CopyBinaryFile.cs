using System.IO;
using System.Collections.Generic;

class CopyBinaryFIle
{
    static void Main()
    {
        string fileInput = @"..\..\CopyBinaryFile.cs";
        string fileOutput = @"..\..\output.txt";

        List<byte[]> inputBytes = new List<byte[]>();
        List<int> inputByteLengths = new List<int>();
        int bufferSize = 128;
        byte[] buffer = new byte[bufferSize];
        int readBytes = 0;

        // Store the file bytes in inputBytes based on a buffer size.
        using (var source = new FileStream(fileInput, FileMode.Open))
        {
            while ((readBytes = source.Read(buffer, 0, buffer.Length)) != 0)
            {
                inputByteLengths.Add(readBytes);
                inputBytes.Add(buffer);
                buffer = new byte[bufferSize];
                readBytes = 0;
            }
        }
        
        // Get the inputBytes and make them in a file again.
        using (var destination = new FileStream(fileOutput, FileMode.Create))
        {
            for (int i = 0; i < inputBytes.Count; i++)
            {
                destination.Write(inputBytes[i], 0, inputByteLengths[i]);
            }
        }
    }
}
