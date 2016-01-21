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

        private ILayout Layout
        {
            get
            {
                return this.layout;
            }
            set
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

        public abstract void Append(string message, SeverityLevel severity);
    }
}
