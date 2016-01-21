namespace LoggerLibrary.Interfaces
{
    using LoggerLibrary.Enums;

    public interface IAppender
    {
        void Append(string message, SeverityLevel severity);
    }
}
