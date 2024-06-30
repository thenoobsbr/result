using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record ConfigurationErrorFail : Fail
{
    private const string CODE = "config_error";
    private const string MESSAGE = "Configuration error";

    public ConfigurationErrorFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
