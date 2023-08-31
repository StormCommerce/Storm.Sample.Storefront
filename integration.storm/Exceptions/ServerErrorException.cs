using System;

namespace Integration.Storm.Exceptions
{
    class ServerErrorException : Exception
    {
        public int StatusCode { get; set; }

        public ServerErrorException(int code, string message) : base(message)
        {
            StatusCode = code;
        }
    }
   
}
