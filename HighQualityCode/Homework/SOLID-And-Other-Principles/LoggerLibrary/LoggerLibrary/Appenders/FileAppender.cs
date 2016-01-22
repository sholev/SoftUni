namespace LoggerLibrary.Appenders
{
    using System.IO;
    using System.Linq;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public class FileAppender : Appender
    {
        private string filePath;

        public FileAppender(ILayout layout, string filePath, SeverityLevel? reportAppendThreshold = null)
            : base(layout, reportAppendThreshold)
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
                string path = string.Join(string.Empty, value.Take(lastSlashIndex));

                if (!Directory.Exists(path))
                {
                    throw new DirectoryNotFoundException("Invalid file directory.");
                }

                this.filePath = value;
            }
        }

        public override void Append(string message, SeverityLevel severity)
        {
            if (this.ShouldAppend(severity))
            {
                this.FormatByLayout(message, severity);

                using (var writer = new StreamWriter(this.FilePath, true))
                {
                    writer.WriteLineAsync(this.FormattedMessage);
                }
            }
        }
    }
}
