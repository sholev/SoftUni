namespace AC_TestingSystem.Work
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AC_TestingSystem.Core;
    using AC_TestingSystem.Data;
    using AC_TestingSystem.Interfaces;
    using AC_TestingSystem.Models;

    public class Controller
    {
        private readonly Engine engine;

        private readonly Repository repository;

        public Controller(Engine engine, Repository repository)
        {
            this.engine = engine;
            this.repository = repository;
        }

        public string ExecuteCommand()
        {
            var command = this.engine.Command;
            string output;

            switch (command.Name)
            {
                case "RegisterStationaryAirConditioner":
                    this.engine.ValidateParametersCount(command, 4);
                    output = this.RegisterStationaryAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        command.Parameters[2],
                        int.Parse(command.Parameters[3]));
                    break;

                case "RegisterCarAirConditioner":
                    this.engine.ValidateParametersCount(command, 3);
                    output = this.RegisterCarAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        int.Parse(command.Parameters[2]));
                    break;

                case "RegisterPlaneAirConditioner":
                    this.engine.ValidateParametersCount(command, 4);
                    output = this.RegisterPlaneAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        int.Parse(command.Parameters[2]),
                        command.Parameters[3]);
                    break;
                case "TestAirConditioner":
                    this.engine.ValidateParametersCount(command, 2);
                    output = this.TestAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1]);
                    break;

                case "FindAirConditioner":
                    this.engine.ValidateParametersCount(command, 2);
                    output = this.FindAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1]);
                    break;

                case "FindReport":
                    this.engine.ValidateParametersCount(command, 2);
                    output = this.FindReport(
                        command.Parameters[0],
                        command.Parameters[1]);
                    break;

                case "Status":
                    this.engine.ValidateParametersCount(command, 0);
                    output = this.Status();
                    break;

                case "FindAllReportsByManufacturer":
                    this.engine.ValidateParametersCount(command, 1);
                    output = this.FindAllReportsByManufacturer(command.Parameters[0]);
                    break;
                default:
                    throw new IndexOutOfRangeException(Constants.InvalidCommand);
            }
            
            return output;
        }

        /// <summary>
        /// Get a status describing how many of the 
        /// air conditioners in the repository
        /// have reports.
        /// </summary>
        /// <returns></returns>
        private string Status()
        {
            int reports = this.repository.GetReportsCount();
            double airConditioners = this.repository.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Constants.Status, percent);
        }

        private string FindAllReportsByManufacturer(string manufacturer)
        {
            List<IReport> reports = this.repository.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Constants.NoReports;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }

        private string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            AirConditioner airConditioner = new AirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            this.repository.AddAirConditioner(airConditioner);
            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }

        private string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            AirConditioner airConditioner = new AirConditioner(manufacturer, model, volumeCoverage);
            this.repository.AddAirConditioner(airConditioner);
            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }

        /// <summary>
        /// Register an air conditioner which will be used in a plane.
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the air conditioner.</param>
        /// <param name="model">The manufacturer of the air conditioner.</param>
        /// <param name="volumeCoverage">The volume coverege of the air conditioner.</param>
        /// <param name="electricityUsed">The electricity used by the air conditioner.</param>
        /// <returns>Returns a string with information about the registered air conditioner.</returns>
        private string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            AirConditioner airConditioner = new AirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            this.repository.AddAirConditioner(airConditioner);
            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }

        private string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.repository.GetAirConditioner(manufacturer, model);
            airConditioner.EnergyRating += 5;
            var mark = airConditioner.Test();
            this.repository.AddReport(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            return string.Format(Constants.Test, model, manufacturer);
        }

        /// <summary>
        /// Find air conditioner by given model and manufacturer.
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the air conditioner.</param>
        /// <param name="model">The manufacturer of the air conditioner.</param>
        /// <returns></returns>
        private string FindAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.repository.GetAirConditioner(manufacturer, model);
            return airConditioner.ToString();
        }

        private string FindReport(string manufacturer, string model)
        {
            IReport report = this.repository.GetReport(manufacturer, model);
            return report.ToString();
        }
    }
}
