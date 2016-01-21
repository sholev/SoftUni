namespace LoggerLibrary.Appenders
{
    using System;

    using LoggerLibrary.Enums;
    using LoggerLibrary.Interfaces;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
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

        protected string FormattedMessage { get; set; }

        protected void FormatByLayout(string message, SeverityLevel severity)
        {
            this.FormattedMessage = this.Layout.FormatMessage(message, severity);
        }

        public abstract void Append(string message, SeverityLevel severity);
    }
}
