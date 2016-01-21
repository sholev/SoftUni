namespace LoggerLibrary.Appenders
{
    using System.IO;
    using System.Linq;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public class FileAppender : Appender
    {
        private string filePath;

        public FileAppender(ILayout layout, string filePath)
            : base(layout)
        {
            this.FilePath = filePath;
        }

        private string FilePath
        {
            get
            {
                return this.filePath;
            }

            set
            {
                int lastSlashIndex = value.LastIndexOf('\\');
                string path = string.Join(string.Empty, value.Take(lastSlashIndex).ToArray());

                if (!Directory.Exists(path))
                {
                    throw new DirectoryNotFoundException("Invalid file directory.");
                }

                this.filePath = value;
            }
        }

        public override void Append(string message, SeverityLevel severity)
        {
            this.FormatByLayout(message, severity);

            using (StreamWriter writer = new StreamWriter(this.FilePath, true))
            {
                writer.WriteLineAsync(this.FormattedMessage);
            }
        }
    }
}
