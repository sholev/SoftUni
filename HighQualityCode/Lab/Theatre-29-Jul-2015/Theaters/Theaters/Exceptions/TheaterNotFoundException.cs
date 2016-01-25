namespace Theaters.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class TheaterNotFoundException : Exception
    {
        public TheaterNotFoundException()
        {
        }

        public TheaterNotFoundException(string message) 
            : base(message)
        {
        }

        public TheaterNotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected TheaterNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}