using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record ResourceLockedFail : Fail
{
    private const string CODE = "resource_locked";
    private const string MESSAGE = "Resource is locked";

    public ResourceLockedFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
