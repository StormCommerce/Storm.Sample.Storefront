using System;

namespace Integration.Storm.Exceptions;

public class RecordNotFoundException: Exception
{
    public int StatusCode { get; set; }

    public RecordNotFoundException(int code, string message): base(message)
    {
        StatusCode = code;
    }
}