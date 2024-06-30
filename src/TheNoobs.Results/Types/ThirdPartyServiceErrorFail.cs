using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record ThirdPartyServiceErrorFail : Fail
{
    private const string CODE = "third_party_error";
    private const string MESSAGE = "Error from third-party service";

    public ThirdPartyServiceErrorFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
