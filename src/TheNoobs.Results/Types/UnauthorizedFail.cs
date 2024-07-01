using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record UnauthorizedFail : Fail
{
    private const string CODE = "unauthorized";
    private const string MESSAGE = "Unauthorized access";

    public UnauthorizedFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
