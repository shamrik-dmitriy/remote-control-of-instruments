using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Devices.SMB100A
{
    [Serializable]
    public sealed class Smb100AException : ApplicationException
    {
        public Smb100AException()
        {
        }

        public Smb100AException(string message) : base(message)
        {
        }

        public Smb100AException(string message, SystemException innerException) : base(message, innerException)
        {
        }

        protected Smb100AException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(
            serializationInfo, streamingContext)
        {
        }
    }
}