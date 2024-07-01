using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record TimeoutFail : Fail
{
    private const string CODE = "timeout";
    private const string MESSAGE = "Request timed out";

    public TimeoutFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
