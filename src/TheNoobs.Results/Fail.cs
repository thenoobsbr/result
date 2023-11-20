namespace TheNoobs.Results;

public abstract record Fail(string message, string code)
{
    public string Message { get; } = message;
    public string Code { get; } = code;
}
