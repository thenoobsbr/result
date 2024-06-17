namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<TTarget> Bind<TValue, TTarget>(this Result<TValue> result, Func<TValue, Result<TTarget>> bind)
    {
        if (!result.IsSuccess)
        {
            return new Result<TTarget>(result.Fail!);
        }

        return bind(result.Value);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(this ValueTask<Result<TValue>> resultAsync, Func<TValue, Result<TTarget>> bind)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new Result<TTarget>(firstResult.Fail!);
        }

        return bind(firstResult.Value);
    }
    
    public static async Task<Result<TTarget>> BindAsync<TValue, TTarget>(this Task<Result<TValue>> resultAsync, Func<TValue, Result<TTarget>> bind)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new Result<TTarget>(firstResult.Fail!);
        }

        return bind(firstResult.Value);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(this ValueTask<Result<TValue>> resultAsync, Func<TValue, ValueTask<Result<TTarget>>> bindAsync)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new Result<TTarget>(firstResult.Fail!);
        }

        return await bindAsync(firstResult.Value).ConfigureAwait(false);
    }
    
    public static async Task<Result<TTarget>> BindAsync<TValue, TTarget>(this Task<Result<TValue>> resultAsync, Func<TValue, Task<Result<TTarget>>> bindAsync)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new Result<TTarget>(firstResult.Fail!);
        }

        return await bindAsync(firstResult.Value).ConfigureAwait(false);
    }
}

