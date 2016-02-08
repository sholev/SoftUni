namespace AC_TestingSystem.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException()
        {
        }

        public NonExistantEntryException(string message) : base(message)
        {
        }

        public NonExistantEntryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonExistantEntryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}