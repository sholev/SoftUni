namespace LoggerLibrary.Interfaces
{
    using System;

    using LoggerLibrary.Enums;

    public interface ILayout
    {
        string FormatMessage(string message, SeverityLevel level, DateTime? time = null);
    }
}
