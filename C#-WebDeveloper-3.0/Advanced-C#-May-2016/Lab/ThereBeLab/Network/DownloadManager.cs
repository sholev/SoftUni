namespace ThereBeLab.Network
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using ThereBeLab.IO;
    using ThereBeLab.IO.File;
    using ThereBeLab.Messages;

    public class DownloadManager
    {
        public static void DownloadAsync(string fileUrl)
        {
            Download(fileUrl, true);
        }

        public static void Download(string fileUrl, bool async = false)
        {
            WebClient webClient = new WebClient();

            try
            {
                OutputWriter.WriteMessageOnNewLine(InformationMessages.DownloadingStarted);

                var nameOfFile = ExtractNameOfFile(fileUrl);
                var downloadPath = $"{SessionData.CurrentPath}/{nameOfFile}";

                if (async)
                {
                    webClient.DownloadFileCompleted += (sender, args) => OutputWriter.WriteMessageOnNewLine(InformationMessages.DownloadingFinished);
                    webClient.DownloadFileAsync(new Uri(fileUrl), downloadPath);
                }
                else
                {
                    webClient.DownloadFile(fileUrl, downloadPath);
                    OutputWriter.WriteMessageOnNewLine(InformationMessages.DownloadingFinished);
                }

            }
            catch (WebException e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private static string ExtractNameOfFile(string fileUrl)
        {
            int lastSlashIndex = fileUrl.LastIndexOf("/", StringComparison.Ordinal);

            if (lastSlashIndex == -1)
            {
                throw new WebException(ExceptionMessages.InvalidPath);
            }

            return fileUrl.Substring(lastSlashIndex + 1);
        }
    }
}
