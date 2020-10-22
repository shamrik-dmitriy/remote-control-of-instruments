using System;
using System.Runtime.Serialization;

namespace Shamrik.Dmitriy.Devices.Exchanges
{
    /// <summary>
    ///     Специфический класс исключений, предназначенный для исключений при работе со службой обмена
    /// </summary>
    [Serializable]
    public sealed class ExchangeServiceException : ApplicationException
    {
        public ExchangeServiceException()
        {
        }

        public ExchangeServiceException(string message) : base(message)
        {
        }

        public ExchangeServiceException(string message, SystemException innerException) : base(message,
            innerException)
        {
        }

        protected ExchangeServiceException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(
                serializationInfo, streamingContext)
        {
        }
    }
}