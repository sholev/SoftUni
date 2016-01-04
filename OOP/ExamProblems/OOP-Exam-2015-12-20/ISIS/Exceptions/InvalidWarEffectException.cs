namespace ISIS.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class InvalidWarEffectException : Exception
    {
        public InvalidWarEffectException()
        {
        }

        public InvalidWarEffectException(string message) 
            : base(message)
        {
        }

        public InvalidWarEffectException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected InvalidWarEffectException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}