using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record DataProcessingFail : Fail
{
    private const string CODE = "data_processing_error";
    private const string MESSAGE = "Error processing data";

    public DataProcessingFail(
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
    }
}
