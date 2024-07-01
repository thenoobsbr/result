using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record ServerErrorFail : Fail
{
    private const string CODE = "server_error";
    private const string MESSAGE = "Internal server error";

    public ServerErrorFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
