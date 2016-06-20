namespace ThereBeLab.IO.File
{
    using System;
    using System.IO;

    using ThereBeLab.IO;
    using ThereBeLab.Messages;

    public class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                var mismatchPath = GetMismatchPath(expectedOutputPath);

                var actualOutputLines = File.ReadAllLines(userOutputPath);
                var expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                var mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

        }

        private static string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            var output = String.Empty;

            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            int minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
            var mismatches = new string[minOutputLines];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            for (int i = 0; i < minOutputLines; i++)
            {
                var actualLine = actualOutputLines[i];
                var expectedLine = expectedOutputLines[i];

                if (actualLine != expectedLine)
                {
                    output = $"Mismatch at line {i} -- expected \"{expectedLine}\" , actual: \"{actualLine}\"";
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            var lastSlashIndex = expectedOutputPath.LastIndexOf(@"\", StringComparison.Ordinal);
            var directoryPath = lastSlashIndex == -1
                                    ? Directory.GetCurrentDirectory()
                                    : expectedOutputPath.Substring(0, lastSlashIndex);

            var mismatchPath = directoryPath + @"\Mismatches.txt";
            return mismatchPath;
        }

        private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchesPath)
        {
            if (hasMismatch)
            {
                foreach (var mismatch in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(mismatch);
                }

                try
                {
                    File.WriteAllLines(mismatchesPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches");
            }
        }
    }
}
