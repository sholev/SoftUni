﻿namespace AC_TestingSystem.Models
{
    using System;
    using System.Linq;

    using AC_TestingSystem.Data;

    public class Command
    {
        public Command(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));

                this.Parameters = line.Substring(line.IndexOf(' '))
                    .Split(new[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToArray();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}
