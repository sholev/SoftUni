namespace EducationSystem.Core
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException()
        {
        }

        public AuthorizationFailedException(string message) 
            : base(message)
        {
        }

        public AuthorizationFailedException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected AuthorizationFailedException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}