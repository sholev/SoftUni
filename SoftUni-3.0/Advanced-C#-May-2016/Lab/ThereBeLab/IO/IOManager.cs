namespace ThereBeLab.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using ThereBeLab.Messages;

    public static class IOManager
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIndentation = path.Split('\\').Length;
            Queue<string> subFolders =  new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count > 0)
            {
                var currentPath = subFolders.Dequeue();
                var indentation = currentPath.Split('\\').Length - initialIndentation;

                OutputWriter.WriteMessageOnNewLine($"{new string('-', indentation)}{currentPath}");

                foreach (var file in Directory.GetFiles(currentPath))
                {
                    int lastSlashIndex = file.LastIndexOf(@"\", StringComparison.Ordinal);
                    var fileName = file.Substring(lastSlashIndex);
                    OutputWriter.WriteMessageOnNewLine(new string('-', lastSlashIndex) + fileName);
                }

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
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

        private static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            SessionData.CurrentPath = absolutePath;
        }
    }
}
