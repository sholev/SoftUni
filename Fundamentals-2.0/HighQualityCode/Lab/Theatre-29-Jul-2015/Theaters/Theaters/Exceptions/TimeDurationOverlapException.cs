namespace Theaters.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException()
        {
        }

        public TimeDurationOverlapException(string message)
            : base(message)
        {
        }

        public TimeDurationOverlapException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected TimeDurationOverlapException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}