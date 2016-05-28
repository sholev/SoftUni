namespace LibraryTests
{
    using LoggerLibrary.Appenders;
    using LoggerLibrary.Enums;
    using LoggerLibrary.Layouts;
    using LoggerLibrary.Loggers;

    public class TestProgram
    {
        public static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout, SeverityLevel.Error);
            var fileAppender = new FileAppender(xmlLayout, "..\\..\\..\\FileAppenderOutput.txt");

            var logger = new Logger(consoleAppender, fileAppender);

            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
