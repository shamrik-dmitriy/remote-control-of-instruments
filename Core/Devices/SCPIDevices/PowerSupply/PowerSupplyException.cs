using System;
using System.Runtime.Serialization;

namespace Core.Devices.SCPIDevices.PowerSupply
{
    /// <summary>
    ///     Специфический класс исключений, предназначенный для исключительных ситуаций с источником питания
    /// </summary>
    [Serializable]
    public sealed class PowerSupplyException : ApplicationException
    {
        public PowerSupplyException()
        {
        }

        public PowerSupplyException(string message) : base(message)
        {
        }

        public PowerSupplyException(string message, SystemException innerException) : base(message, innerException)
        {
        }

        protected PowerSupplyException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(
            serializationInfo, streamingContext)
        {
        }
    }
}