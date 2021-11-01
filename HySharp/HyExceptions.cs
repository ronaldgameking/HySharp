using System;

namespace HySharp
{
    public class InvalidKeyException : Exception
    {
        public InvalidKeyException() { }
        public InvalidKeyException(string message) : base(message) { }
        public InvalidKeyException(string message, Exception inner) : base(message, inner) { }
    }

    public class RequestLimitException : Exception
    {
        public RequestLimitException() { }
        public RequestLimitException(string message) : base(message) { }
        public RequestLimitException(string message, Exception inner) : base(message, inner) { }
    }
}
