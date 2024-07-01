using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record ValidationFail : Fail
{
    private const string CODE = "validation_failed";
    private const string MESSAGE = "Validation failed";

    public ValidationFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
