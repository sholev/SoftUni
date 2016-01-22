namespace LoggerLibrary.Appenders
{
    using System;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout, SeverityLevel? reportAppendThreshold = null)
        {
            this.Layout = layout;
            this.ReportAppendThreshold = reportAppendThreshold;
        }

        protected ILayout Layout
        {
            get
            {
                return this.layout;
            }
            private set
            {
                if (value == null)
                {
                    const string ParamName = nameof(this.layout);
                    throw new ArgumentNullException(
                        ParamName,
                        $"{ParamName} should not be null.");
                }

                this.layout = value;
            }
        }

        public SeverityLevel? ReportAppendThreshold { get; set; }

        protected string FormattedMessage { get; set; }

        protected bool ShouldAppend(SeverityLevel severity)
        {
            return this.ReportAppendThreshold == null || this.ReportAppendThreshold >= severity;
        }

        protected void FormatByLayout(string message, SeverityLevel severity)
        {
            this.FormattedMessage = this.Layout.FormatMessage(message, severity);
        }

        public abstract void Append(string message, SeverityLevel severity);
    }
}
