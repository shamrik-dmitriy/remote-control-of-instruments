using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExchangeServices
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