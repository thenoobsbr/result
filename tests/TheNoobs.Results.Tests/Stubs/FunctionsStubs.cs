using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Tests.Stubs;

public static class FunctionsStubs
{
    public static ValueTask<Result<T>> SuccessValueTaskAsync<T>(T value)
    {
        return new ValueTask<Result<T>>(new Result<T>(value));
    }
    
    public static async Task<Result<int>> GetSuccessTaskAsync()
    {
        return await GetSuccessAsync();
    }
    
    public static ValueTask<Result<int>> GetSuccessAsync()
    {
        return ValueTask.FromResult(new Result<int>(1));
    }
    
    public static ValueTask<Result<int>> GetFailAsync(Fail? fail = null)
    {
        return ValueTask.FromResult(new Result<int>(fail ?? new TestFail()));
    }
    
    public static Result<int> GetSuccess()
    {
        return 1;
    }

    public static Result<int> GetFail(Fail? fail = null)
    {
        return fail ?? new TestFail();
    }
    
    public static Result<int> Throw()
    {
        throw new Exception();
    }
    
    public static async ValueTask<Result<int>> ThrowAsync()
    {
        return await ValueTask.FromResult(Throw());
    }
    
    public static async Task<Result<int>> ThrowTaskAsync()
    {
        return await ThrowAsync();
    }
}
