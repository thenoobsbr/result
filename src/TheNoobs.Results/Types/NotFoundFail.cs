using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record NotFoundFail : Fail
{
    private const string CODE = "not_found";
    private const string MESSAGE = "Resource not found";

    public NotFoundFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
