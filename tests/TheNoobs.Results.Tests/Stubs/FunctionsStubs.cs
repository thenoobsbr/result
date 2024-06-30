using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Tests.Stubs;

public static class FunctionsStubs
{   
    public static async Task<Result<int>> GetSuccessTaskAsync(int value = 1)
    {
        return await GetSuccessAsync(value);
    }
    
    public static ValueTask<Result<int>> GetSuccessAsync(int value = 1)
    {
        return ValueTask.FromResult(new Result<int>(value));
    }
    
    public static ValueTask<Result<int>> GetFailAsync(Fail? fail = null)
    {
        return ValueTask.FromResult(new Result<int>(fail ?? new TestFail()));
    }
    
    public static Result<int> GetSuccess(int value = 1)
    {
        return value;
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
