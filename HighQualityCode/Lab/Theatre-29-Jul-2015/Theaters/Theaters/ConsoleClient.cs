namespace Theaters
{
    using System;
    using System.Globalization;
    using System.Threading;

    using Theaters.Business;
    using Theaters.Interfaces;

    internal class ConsoleClient
    {
        private static readonly IPerformanceDatabase PerformancesDatabase = new PerformanceDatabase();
        
        internal static void Main()
        {
            CommandTools commandTools = new CommandTools();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            while (true)
            {
                string inputCommand = Console.ReadLine();
                if (inputCommand == null)
                {
                    return;
                }

                if (inputCommand == string.Empty)
                {
                    continue;
                }

                string[] inputParameters = inputCommand.Split("(,)".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string command = inputParameters[0];
                string output;

                try
                {
                    switch (command)
                    {
                        case "AddTheatre":
                            var theaterName = inputParameters[1];

                            output = commandTools.ExecuteAddTheaterCommand(PerformancesDatabase, theaterName);
                            break;

                        case "PrintAllTheatres":
                            var theaters = PerformancesDatabase.ListTheaters();

                            output = commandTools.ExecutePrintAllTheatersCommand(theaters);
                            break;

                        case "AddPerformance":
                            theaterName = inputParameters[1].Trim();
                            string performanceTitle = inputParameters[2].Trim();
                            DateTime startDateTime = DateTime.ParseExact(
                                inputParameters[3].Trim(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                            TimeSpan duration = TimeSpan.Parse(inputParameters[4].Trim());
                            decimal price = decimal.Parse(inputParameters[5].Trim());

                            PerformancesDatabase.AddPerformance(
                                theaterName,
                                performanceTitle,
                                startDateTime,
                                duration,
                                price);

                            output = "Performance added";
                            break;

                        case "PrintAllPerformances":
                            var performances = PerformancesDatabase.ListAllPerformances();

                            output = commandTools.ExecutePrintAllPerformancesCommand(performances);
                            break;

                        case "PrintPerformances":
                            string theater = inputParameters[1];
                            performances = PerformancesDatabase.ListPerformances(theater);

                            output = commandTools.ExecutePrintPerformancesCommand(performances);
                            break;

                        default:
                            output = "Invalid command!";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    output = "Error: " + ex.Message;
                }

                Console.WriteLine(output);
            }
        }
    }
}
