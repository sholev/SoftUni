namespace LibraryTests
{
    using System;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string message, SeverityLevel severity, DateTime? time = null)
        {
            if (time == null)
            {
                time = DateTime.Now;
            }

            string formattedMessage =
                "<log>" + Environment.NewLine +
                $"\t<date>{time}</date>" + Environment.NewLine +
                $"\t<level>{severity}</level>" + Environment.NewLine +
                $"\t<message>{message}</message>" + Environment.NewLine +
                "</log>";

            return formattedMessage;
        }
    }
}
