using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record AggregateFail : Fail
{
    public Fail[] Failures { get; }

    private const string CODE = "aggregate_fail";
    private const string MESSAGE = "Some of the operations failed";

    public AggregateFail(
        Fail[] failures,
        string message = MESSAGE,
        string code = CODE,
        Exception? exception = null)
        : base(message, code, exception)
    {
        Failures = failures;
    }
}

