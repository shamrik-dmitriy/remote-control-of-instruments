using System;
using System.Runtime.Serialization;

namespace Shamrik.Dmitriy.Devices.SCPIDevices.SignalGenerator
{
    /// <summary>
    ///     Специфический класс исключений, предназначенный для исключительных ситуаций с генератором сигналов
    /// </summary>
    [Serializable]
    public sealed class SignalGeneratorException : ApplicationException
    {
        public SignalGeneratorException()
        {
        }

        public SignalGeneratorException(string message, SystemException innException) : base(message, innException)
        {
        }

        public SignalGeneratorException(string message) : base(message)
        {
        }

        protected SignalGeneratorException(SerializationInfo serializationInfo, StreamingContext streamingContext) :
            base(serializationInfo, streamingContext)
        {
        }
    }
}