using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Devices.N5746A
{
    [Serializable]
    public sealed class N5746AException : ApplicationException
    {
        public N5746AException()
        {
        }

        public N5746AException(string message) : base(message)
        {
        }

        public N5746AException(string message, SystemException innerException) : base(message, innerException)
        {
        }

        protected N5746AException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(
            serializationInfo, streamingContext)
        {
        }
    }
}