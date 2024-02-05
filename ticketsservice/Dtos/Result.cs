using System.Net;

namespace ticketsservice.Dtos;

public class Result
{
    public bool Succeeded => Error == null;
    public string Error { get; protected set; }
    public string Message { get; protected set; }
    public HttpStatusCode StatusCode { get; protected set; }

    public static Result Success(HttpStatusCode statusCode, string Message) =>
        new Result { StatusCode = statusCode, Message = Message };

    public static Result Failed(HttpStatusCode statusCode, string error) =>
        new Result { StatusCode = statusCode, Error = error };
}

public class Result<TValue>
{
    public bool Succeeded => Error == null;
    public string Error { get; protected set; }
    public HttpStatusCode StatusCode { get; protected set; }
    public TValue Value { get; protected set; }

    public static Result<TValue> Success(HttpStatusCode statusCode, TValue value) =>
        new Result<TValue> { StatusCode = statusCode, Value = value };

    public static Result<TValue> Failed(HttpStatusCode statusCode, string error) =>
        new Result<TValue> { StatusCode = statusCode, Error = error };
}