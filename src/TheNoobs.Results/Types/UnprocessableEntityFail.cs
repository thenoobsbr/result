using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record UnprocessableEntityFail : Fail
{
    private const string CODE = "unprocessable_entity";
    private const string MESSAGE = "Unprocessable entity";

    public UnprocessableEntityFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
