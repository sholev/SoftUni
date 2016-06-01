namespace ThereBeLab.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using ThereBeLab.Messages;

    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            var path = SessionData.CurrentPath;
            int initialIndentation = path.Split('\\').Length;
            int initialDepth = path.Count(c => c.Equals('\\'));

            Queue<string> subFolders =  new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count > 0)
            {
                var currentPath = subFolders.Dequeue();
                var indentation = currentPath.Split('\\').Length - initialIndentation;
                var currentDepth = currentPath.Count(c => c.Equals('\\'));

                OutputWriter.WriteMessageOnNewLine($"{new string('-', indentation)}{currentPath}");

                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int lastSlashIndex = file.LastIndexOf("\\", StringComparison.Ordinal);
                        var fileName = file.Substring(lastSlashIndex);
                        OutputWriter.WriteMessageOnNewLine($"+{new string('-', currentDepth)}{fileName}");
                    }

                    if (currentDepth - initialDepth < depth)
                    {
                        foreach (string directoryPath in Directory.GetDirectories(currentPath))
                        {
                            subFolders.Enqueue(directoryPath);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }

            }
        }

        public static string CreateDirectoryInCurrentFolder(string name)
        {
            var path = Directory.GetCurrentDirectory() + @"\" + name;
            Directory.CreateDirectory(path);

            return path;
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                var currentPath = SessionData.CurrentPath;
                int lastSlashIndex = currentPath.LastIndexOf(@"\");
                var newPath = currentPath.Substring(0, lastSlashIndex);
                SessionData.CurrentPath = newPath;
            }
            else
            {
                var currentPath = SessionData.CurrentPath;
                currentPath += @"\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            SessionData.CurrentPath = absolutePath;
        }
    }
}
