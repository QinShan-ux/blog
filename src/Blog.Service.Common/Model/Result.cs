namespace Blog.Service.Common.Model;

public class Result
{
    internal Result(bool succeeded, string msg)
    {
        RetCode = succeeded ? "1" : "0";
        RetMsg  = msg;
    }

    internal Result(bool succeeded)
    {
        RetCode = succeeded ? "1" : "0";
        RetMsg  = string.Empty;
    }

    public string RetCode { get; init; }

    public string RetMsg { get; init; }

    public static Result Failure(string errorMsg)
    {
        return new Result(false, errorMsg);
    }
}
public class Result<T>
{
    internal Result(bool succeeded, string msg)
    {
        RetCode = succeeded ? "1" : "0";
        RetMsg  = msg;
    }

    internal Result(bool succeeded, string msg, T? data)
    {
        RetCode = succeeded ? "1" : "0";
        RetMsg  = msg;
        Data    = data;
    }

    internal Result(bool succeeded, T? data)
    {
        RetCode = succeeded ? "1" : "0";
        RetMsg  = string.Empty;
        Data    = data;
    }

    public string RetCode { get; init; }

    public string RetMsg { get; init; }

    public T? Data { get; init; }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, data);
    }

    public static Result<T> Success(string msg, T data)
    {
        return new Result<T>(true, msg, data);
    }
}
