namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<TTarget> Bind<TValue, TTarget>(
        this Result<TValue> current,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        if (!current.IsSuccess)
        {
            return new BindResult<TTarget>(current.Fail!);
        }

        var bindParameter = current as BindResult<TValue> ?? new BindResult<TValue>(null, current);
        var bindResult = bind(bindParameter);
        if (!bindResult.IsSuccess)
        {
            return bindResult;
        }
        
        return new BindResult<TTarget>(
            bindParameter, 
            bindResult);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this Result<TValue> current,
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        if (!current.IsSuccess)
        {
            return new BindResult<TTarget>(current.Fail!);
        }

        var bindParameter = current as BindResult<TValue> ?? new BindResult<TValue>(null, current);
        var bindResult = await bindAsync(bindParameter).ConfigureAwait(false);
        if (!bindResult.IsSuccess)
        {
            return bindResult;
        }
        
        return new BindResult<TTarget>(
            bindParameter, 
            bindResult);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this Result<TValue> current,
        Func<BindResult<TValue>, Task<Result<TTarget>>> bindAsync)
    {
        if (!current.IsSuccess)
        {
            return new BindResult<TTarget>(current.Fail!);
        }

        var bindParameter = current as BindResult<TValue> ?? new BindResult<TValue>(null, current);
        var bindResult = await bindAsync(bindParameter).ConfigureAwait(false);
        if (!bindResult.IsSuccess)
        {
            return bindResult;
        }
        
        return new BindResult<TTarget>(
            bindParameter, 
            bindResult);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this ValueTask<Result<TValue>> currentAsync,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        var current = await currentAsync.ConfigureAwait(false);
        if (!current.IsSuccess)
        {
            return new BindResult<TTarget>(current.Fail!);
        }

        var bindParameter = current as BindResult<TValue> ?? new BindResult<TValue>(null, current);
        var bindResult = bind(bindParameter);
        if (!bindResult.IsSuccess)
        {
            return bindResult;
        }
        
        return new BindResult<TTarget>(
            bindParameter, 
            bindResult);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this Task<Result<TValue>> currentAsync,
        Func<BindResult<TValue>, Result<TTarget>> bind)
    {
        var current = await currentAsync.ConfigureAwait(false);
        if (!current.IsSuccess)
        {
            return new BindResult<TTarget>(current.Fail!);
        }

        var bindParameter = current as BindResult<TValue> ?? new BindResult<TValue>(null, current);
        var bindResult = bind(bindParameter);
        if (!bindResult.IsSuccess)
        {
            return bindResult;
        }
        
        return new BindResult<TTarget>(
            bindParameter, 
            bindResult);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this ValueTask<Result<TValue>> currentAsync,
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        if (!current.IsSuccess)
        {
            return new BindResult<TTarget>(current.Fail!);
        }

        var bindParameter = current as BindResult<TValue> ?? new BindResult<TValue>(null, current);
        var bindResult = await bindAsync(bindParameter).ConfigureAwait(false);
        if (!bindResult.IsSuccess)
        {
            return bindResult;
        }
        
        return new BindResult<TTarget>(
            bindParameter, 
            bindResult);
    }
    
    public static async ValueTask<Result<TTarget>> BindAsync<TValue, TTarget>(
        this Task<Result<TValue>> currentAsync, 
        Func<BindResult<TValue>, ValueTask<Result<TTarget>>> bindAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        if (!current.IsSuccess)
        {
            return new BindResult<TTarget>(current.Fail!);
        }

        var bindParameter = current as BindResult<TValue> ?? new BindResult<TValue>(null, current);
        var bindResult = await bindAsync(bindParameter).ConfigureAwait(false);
        if (!bindResult.IsSuccess)
        {
            return bindResult;
        }
        
        return new BindResult<TTarget>(
            bindParameter, 
            bindResult);
    }
}

