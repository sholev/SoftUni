namespace LoggerLibrary.Loggers
{
    using System;
    using System.Linq;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public class Logger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        private IAppender[] Appenders
        {
            get
            {
                return this.appenders;
            }
            set
            {
                if (value == null)
                {
                    const string ParamName = nameof(this.appenders);
                    throw new ArgumentNullException(
                        ParamName,
                        $"{ParamName} should not be null.");
                }

                if (value.Any(element => element == null))
                {
                    const string ParamName = nameof(this.appenders);
                    throw new ArgumentNullException(
                        ParamName,
                        $"{ParamName} cannot contain null elements.");
                }

                this.appenders = value;
            }
        }

        public void Info(string message)
        {
            this.UseAppenders(message, SeverityLevel.Info);
        }

        public void Warn(string message)
        {
            this.UseAppenders(message, SeverityLevel.Warn);
        }

        public void Error(string message)
        {
            this.UseAppenders(message, SeverityLevel.Error);
        }

        public void Critical(string message)
        {
            this.UseAppenders(message, SeverityLevel.Critical);
        }

        public void Fatal(string message)
        {
            this.UseAppenders(message, SeverityLevel.Fatal);
        }

        private void UseAppenders(string message, SeverityLevel severity)
        {
            foreach (IAppender appender in this.Appenders)
            {
                appender.Append(message, severity);
            }
        }
    }
}
