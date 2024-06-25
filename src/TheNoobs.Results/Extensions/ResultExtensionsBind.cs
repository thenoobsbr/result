namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<TTarget> Bind<TValue, TTarget>(
        this Result<TValue> result,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        if (!result.IsSuccess)
        {
            return new BindResult<TTarget>(result.Fail!);
        }

        var bindResult = result as BindResult<TValue> ?? new BindResult<TValue>(null, result);
        return new BindResult<TTarget>(
            bindResult, 
            bind(new BindResult<TValue>(null, result)));
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this ValueTask<Result<TValue>> resultAsync,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        var result = await resultAsync.ConfigureAwait(false);
        if (!result.IsSuccess)
        {
            return new BindResult<TTarget>(result.Fail!);
        }

        var bindResult = result as BindResult<TValue> ?? new BindResult<TValue>(null, result);
        return new BindResult<TTarget>(
            bindResult,
            bind(result.Value));
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this Task<Result<TValue>> resultAsync,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        var result = await resultAsync.ConfigureAwait(false);
        if (!result.IsSuccess)
        {
            return new BindResult<TTarget>(result.Fail!);
        }

        var bindResult = result as BindResult<TValue> ?? new BindResult<TValue>(null, result);
        return new BindResult<TTarget>(
            bindResult,
            bind(result.Value));
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this ValueTask<Result<TValue>> resultAsync,
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        var bindResult = firstResult as BindResult<TValue> ?? new BindResult<TValue>(null, firstResult);
        var result = await bindAsync(bindResult).ConfigureAwait(false);
        return new BindResult<TTarget>(
            bindResult,
            result);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this Task<Result<TValue>> resultAsync, 
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        var bindResult = firstResult as BindResult<TValue> ?? new BindResult<TValue>(null, firstResult);
        var result = await bindAsync(bindResult).ConfigureAwait(false);
        return new BindResult<TTarget>(
            bindResult,
            result);
    }
}

