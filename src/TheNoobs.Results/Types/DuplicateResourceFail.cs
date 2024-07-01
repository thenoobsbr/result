using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record DuplicateResourceFail : Fail
{
    private const string CODE = "duplicate_resource";
    private const string MESSAGE = "Duplicate resource found";

    public DuplicateResourceFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
