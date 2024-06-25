namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static BindResult<TTarget> Bind<TValue, TTarget>(
        this Result<TValue> result,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        if (!result.IsSuccess)
        {
            return new BindResult<TTarget>(result.Fail!);
        }

        return new BindResult<TTarget>(
            new BindResult<TValue>(null, result), 
            bind(new BindResult<TValue>(null, result)));
    }
    
    public static BindResult<TTarget> Bind<TValue, TTarget>(
        this BindResult<TValue> result,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        if (!result.IsSuccess)
        {
            return new BindResult<TTarget>(result.Fail!);
        }

        return new BindResult<TTarget>(result, bind(result));
    }
    
    
    public static async ValueTask<BindResult<TTarget>> BindAsync<TValue, TTarget>(
        this ValueTask<Result<TValue>> resultAsync,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        return new BindResult<TTarget>(new BindResult<TValue>(null, firstResult), bind(firstResult.Value));
    }
    
    public static async ValueTask<BindResult<TTarget>> BindAsync<TValue, TTarget>(
        this ValueTask<BindResult<TValue>> resultAsync,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        return new BindResult<TTarget>(firstResult, bind(firstResult));
    }
    
    public static async ValueTask<BindResult<TTarget>> BindAsync<TValue, TTarget>(
        this Task<Result<TValue>> resultAsync,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        return new BindResult<TTarget>(
            new BindResult<TValue>(null, firstResult),
            bind(firstResult.Value));
    }
    
    public static async ValueTask<BindResult<TTarget>> BindAsync<TValue, TTarget>(
        this Task<BindResult<TValue>> resultAsync,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        return new BindResult<TTarget>(
            firstResult,
            bind(firstResult));
    }
    
    public static async ValueTask<BindResult<TTarget>> BindAsync<TValue, TTarget>(
        this ValueTask<Result<TValue>> resultAsync,
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        var result = await bindAsync(firstResult.Value).ConfigureAwait(false);
        return new BindResult<TTarget>(new BindResult<TValue>(null, firstResult), result);
    }
    
    public static async ValueTask<BindResult<TTarget>> BindAsync<TValue, TTarget>(
        this ValueTask<BindResult<TValue>> resultAsync,
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        var result = await bindAsync(firstResult).ConfigureAwait(false);
        return new BindResult<TTarget>(firstResult, result);
    }
    
    public static async ValueTask<BindResult<TTarget>> BindAsync<TValue, TTarget>(
        this Task<Result<TValue>> resultAsync, 
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        var result = await bindAsync(firstResult.Value).ConfigureAwait(false);
        return new BindResult<TTarget>(new BindResult<TValue>(null, firstResult), result);
    }
    
    public static async ValueTask<BindResult<TTarget>> BindAsync<TValue, TTarget>(
        this Task<BindResult<TValue>> resultAsync,
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        var firstResult = await resultAsync.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new BindResult<TTarget>(firstResult.Fail!);
        }

        var result = await bindAsync(firstResult).ConfigureAwait(false);
        return new BindResult<TTarget>(firstResult, result);
    }
}

