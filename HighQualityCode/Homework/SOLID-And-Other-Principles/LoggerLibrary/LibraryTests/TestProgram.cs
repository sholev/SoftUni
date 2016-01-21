namespace LibraryTests
{
    using LoggerLibrary.Appenders;
    using LoggerLibrary.Layouts;
    using LoggerLibrary.Loggers;

    public class TestProgram
    {
        public static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = SeverityLevel.Error;
            var fileAppender = new FileAppender(simpleLayout, "..\\..\\..\\FileAppenderOutput.txt");

            var logger = new Logger(consoleAppender, fileAppender);

            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
