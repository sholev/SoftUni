namespace LoggerLibrary.Appenders
{
    using System;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string message, SeverityLevel severity)
        {
            this.FormatByLayout(message, severity);

            Console.WriteLine(this.FormattedMessage);
        }
    }
}
