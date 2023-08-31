using System;

namespace Integration.Storm.Exceptions
{
    public class BadRequestException: Exception
    {
        public int StatusCode { get; set; }

        public BadRequestException(int code, string message): base(message)
        {
            StatusCode = code;
        }

    }
}
    