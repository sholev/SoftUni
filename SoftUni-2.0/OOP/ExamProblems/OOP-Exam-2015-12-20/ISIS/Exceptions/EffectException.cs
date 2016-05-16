namespace ISIS.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class EffectException : Exception
    {
        public EffectException()
        {
        }

        public EffectException(string message) 
            : base(message)
        {
        }

        public EffectException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected EffectException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}