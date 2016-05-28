namespace LoggerLibrary.Appenders
{
    using System;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, SeverityLevel? reportAppendThreshold = null) 
            : base(layout, reportAppendThreshold)
        {
        }

        public override void Append(string message, SeverityLevel severity)
        {
            if (this.ShouldAppend(severity))
            {
                this.FormatByLayout(message, severity);

                Console.WriteLine(this.FormattedMessage);
            }
        }
    }
}
