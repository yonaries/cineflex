using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Responses;

public class SuccessResponse<T>
{
    public bool Success { get; set; } = true;
    public string Message { get; set; }
    public T Data { get; set; }

    public SuccessResponse(T data)
    {
        Data = data;
    }

    public SuccessResponse(string message, T data)
    {
        Message = message;
        Data = data;
    }
}
