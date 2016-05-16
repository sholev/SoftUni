namespace AC_TestingSystem.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException()
        {
        }

        public DuplicateEntryException(string message) : base(message)
        {
        }

        public DuplicateEntryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateEntryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}