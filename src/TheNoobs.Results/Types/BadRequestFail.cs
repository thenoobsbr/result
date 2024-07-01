using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record BadRequestFail : Fail
{
    private const string CODE = "bad_request";
    private const string MESSAGE = "Bad request";

    public BadRequestFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
