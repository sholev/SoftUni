using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    public static class Validation
    {
        public static void CheckIfNegative(decimal number, string message)
        {
            if (number < 0M)
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfNegative(int number, string message)
        {
            if (number < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateName(string name, int minLenth, string message)
        {
            if (String.IsNullOrWhiteSpace(name) || name.Length < minLenth)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateYear(DateTime year, int minYear, string message)
        {
            if (year.Year < minYear)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
