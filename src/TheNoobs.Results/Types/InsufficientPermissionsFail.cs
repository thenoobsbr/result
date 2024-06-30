using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record InsufficientPermissionsFail : Fail
{
    private const string CODE = "insufficient_permissions";
    private const string MESSAGE = "Insufficient permissions";

    public InsufficientPermissionsFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
