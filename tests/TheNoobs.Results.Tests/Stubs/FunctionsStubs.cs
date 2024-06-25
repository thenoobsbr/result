namespace TheNoobs.Results.Tests.Stubs;

public static class FunctionsStubs
{
    public static ValueTask<Result<T>> SuccessValueTaskAsync<T>(T value)
    {
        return new ValueTask<Result<T>>(new Result<T>(value));
    }
}
