using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Tasks.Buisness.Exceptions
{
    public class InvalidBuisnessException : Exception
    {
        public InvalidBuisnessException()
        {
        }

        public InvalidBuisnessException(string message) : base(message)
        {
        }

        public InvalidBuisnessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBuisnessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
