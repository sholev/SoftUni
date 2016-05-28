namespace LoggerLibrary.Layouts
{
    using System;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string message, SeverityLevel severity, DateTime? time = null)
        {
            if (time == null)
            {
                time = DateTime.Now;
            }

            string formattedMessage = $"{time} - {severity} - {message}";

            return formattedMessage;
        }
    }
}
