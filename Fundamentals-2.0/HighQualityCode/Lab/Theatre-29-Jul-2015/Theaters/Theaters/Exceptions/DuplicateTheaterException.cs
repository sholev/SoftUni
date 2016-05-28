namespace Theaters.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class DuplicateTheaterException : Exception
    {
        public DuplicateTheaterException()
        {
        }

        public DuplicateTheaterException(string message)
            : base(message)
        {
        }

        public DuplicateTheaterException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected DuplicateTheaterException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}