namespace ISIS.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class InvalidAttackTypeException : Exception
    {
        public InvalidAttackTypeException()
        {
        }

        public InvalidAttackTypeException(string message) 
            : base(message)
        {
        }

        public InvalidAttackTypeException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidAttackTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}