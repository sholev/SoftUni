namespace BoatRacingSimulator.Utility
{
    using System;

    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;

    public static class Validator
    {
        public static void ValidatePropertyValue(int value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(Constants.IncorrectPropertyValueMessage, propertyName));
            }
        }

        public static void ValidateModelLength(string value, int minModelLength)
        {
            if (value.Length < minModelLength)
            {
                throw new ArgumentException(string.Format(Constants.IncorrectModelLengthMessage, minModelLength));
            }
        }

        public static void ValidateRaceIsSet(IRace race)
        {
            if (race == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        public static void ValidateRaceIsEmpty(IRace race)
        {
            if (race != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}
