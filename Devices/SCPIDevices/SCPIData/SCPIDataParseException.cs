using System;
using System.Runtime.Serialization;

namespace Shamrik.Dmitriy.Devices.SCPIDevices.SCPIData
{
    /// <summary>
    ///     Специфический класс исключений, предназначенный для исключительных ситуаций с парсером данных SCPI
    /// </summary>
    [Serializable]
    public sealed class ASCPIParseDataException : ApplicationException
    {
        public ASCPIParseDataException()
        {
        }

        public ASCPIParseDataException(string message) : base(message)
        {
        }

        public ASCPIParseDataException(string message, SystemException innerException) : base(message, innerException)
        {
        }

        protected ASCPIParseDataException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(
                serializationInfo, streamingContext)
        {
        }
    }
}