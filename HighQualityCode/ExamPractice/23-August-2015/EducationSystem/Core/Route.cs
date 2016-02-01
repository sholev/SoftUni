namespace EducationSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using EducationSystem.Interfaces;

    public class Route : IRoute
    {
        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }

        private void Parse(string routeUrl)
        {
            string[] parameters = routeUrl.Split(
                new[] { "/", "?" }, 
                StringSplitOptions.RemoveEmptyEntries);

            if (parameters.Length < 2)
            {
                throw new InvalidOperationException("The provided route is invalid.");
            }

            this.ControllerName = parameters[0] + "Controller";
            this.ActionName = parameters[1];

            if (parameters.Length > 2)
            {
                this.Parameters = new Dictionary<string, string>();

                string[] parameterPairs = parameters[2].Split('&');
                foreach (string pair in parameterPairs)
                {
                    string[] keyValue = pair.Split('=');
                    string key = WebUtility.UrlDecode(keyValue[0]);
                    string value = WebUtility.UrlDecode(keyValue[1]);
                    this.Parameters.Add(key, value);
                }
            }
        }
    }
}