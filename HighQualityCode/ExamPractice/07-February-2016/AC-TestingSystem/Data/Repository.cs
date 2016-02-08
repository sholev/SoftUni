namespace AC_TestingSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AC_TestingSystem.Exceptions;
    using AC_TestingSystem.Interfaces;
    using AC_TestingSystem.Models;

    public class Repository
    {
        public Repository()
        {
            this.AirConditioners = new Dictionary<string, AirConditioner>();
            this.Reports = new Dictionary<string, IReport>();
        }

        // PERFORMANCE: Using lists when dictionaries will be significantly faster;
        private Dictionary<string, IReport> Reports { get; }

        private Dictionary<string, AirConditioner> AirConditioners { get; }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            string key = this.ConcatStrings(airConditioner.Manufacturer, airConditioner.Model);
            if (this.AirConditioners.ContainsKey(key))
            {
                throw new DuplicateEntryException(Constants.Duplicate);
            }

            this.AirConditioners.Add(key, airConditioner);
        }

        public void RemoveAirConditioner(AirConditioner airConditioner)
        {
            string key = this.ConcatStrings(airConditioner.Manufacturer, airConditioner.Model);
            this.AirConditioners.Remove(key);
        }

        public AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            string key = this.ConcatStrings(manufacturer, model);
            if (!this.AirConditioners.ContainsKey(key))
            {
                throw new NonExistantEntryException(Constants.NonExist);
            }

            var airConditioner = this.AirConditioners[key];
            return airConditioner;
        }

        public int GetAirConditionersCount()
        {
            return this.AirConditioners.Count;
        }

        public void AddReport(IReport report)
        {
            string key = this.ConcatStrings(report.Manufacturer, report.Model);
            
            if (this.Reports.ContainsKey(key))
            {
                throw new DuplicateEntryException(Constants.Duplicate);
            }

            this.Reports.Add(key, report);
        }

        public void RemoveReport(IReport report)
        {
            string key = this.ConcatStrings(report.Manufacturer, report.Model);

            this.Reports.Remove(key);
        }

        public IReport GetReport(string manufacturer, string model)
        {
            string key = this.ConcatStrings(manufacturer, model);

            if (!this.Reports.ContainsKey(key))
            {
                throw new NonExistantEntryException(Constants.NonExist);
            }

            return this.Reports[key];
        }

        public int GetReportsCount()
        {
            return this.Reports.Count;
        }

        public List<IReport> GetReportsByManufacturer(string manufacturer)
        {
            return this.Reports.Values.Where(r => r.Manufacturer.Equals(manufacturer)).ToList();
        }

        private string ConcatStrings(params string[] s)
        {
            var result = string.Join(string.Empty, s);
            return result;
        }
    }
}
