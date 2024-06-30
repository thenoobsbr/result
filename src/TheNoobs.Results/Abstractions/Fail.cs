namespace TheNoobs.Results.Abstractions;

public abstract record Fail
{
    protected Fail(string message, string code, Exception? exception)
    {
        Message = message;
        Code = code;
        Exception = exception;
    }

    public string Message { get; }
    public string Code { get; }
    public Exception? Exception { get; }
}
