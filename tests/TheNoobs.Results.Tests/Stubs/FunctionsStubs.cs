using TheNoobs.Results.Abstractions;
using Void = TheNoobs.Results.Types.Void;

namespace TheNoobs.Results.Tests.Stubs;

public static class FunctionsStubs
{
    public static Result<T> Success<T>(T value)
    {
        return new Result<T>(value);
    }
    
    public static Result<Void> Fail(Fail fail)
    {
        return new Result<Void>(fail);
    }
    
    public static ValueTask<Result<T>> SuccessValueTaskAsync<T>(T value)
    {
        return new ValueTask<Result<T>>(new Result<T>(value));
    }
    
    public static ValueTask<Result<Void>> FailValueTaskAsync(Fail fail)
    {
        return new ValueTask<Result<Void>>(new Result<Void>(fail));
    }
    
    public static Task<Result<T>> SuccessTaskAsync<T>(T value)
    {
        return Task.FromResult(new Result<T>(value));
    }
    
    public static Task<Result<Void>> FailTaskAsync(Fail fail)
    {
        return Task.FromResult(new Result<Void>(fail));
    }
}
