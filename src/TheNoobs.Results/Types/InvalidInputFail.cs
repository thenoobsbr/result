using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record InvalidInputFail : Fail
{
    private const string CODE = "invalid_input";
    private const string MESSAGE = "Invalid input";

    public InvalidInputFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
