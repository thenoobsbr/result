using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record RateLimitExceededFail : Fail
{
    private const string CODE = "rate_limit_exceeded";
    private const string MESSAGE = "Rate limit exceeded";

    public RateLimitExceededFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
