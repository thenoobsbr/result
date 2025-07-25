namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<TOut> TryCatch<TIn, TOut>(
        this Result<TIn> current,
        Func<BindResult<TIn>, Result<TOut>> func,
        Func<Exception, Result<TOut>> fail)
    {
        try
        {
            if (!current.IsSuccess)
            {
                return current.Fail;
            }
            
            var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
            var funcResult = func(bindParameter);

            if (!funcResult.IsSuccess)
            {
                return funcResult.Fail;
            }
            
            return new BindResult<TOut>(current, funcResult);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this Result<TIn> current,
        Func<BindResult<TIn>, ValueTask<Result<TOut>>> funcAsync,
        Func<Exception, Result<TOut>> fail)
    {
        try
        {
            if (!current.IsSuccess)
            {
                return current.Fail;
            }
            
            var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
            var funcResult = await funcAsync(bindParameter).ConfigureAwait(false);
            
            if (!funcResult.IsSuccess)
            {
                return funcResult.Fail;
            }
            
            return new BindResult<TOut>(current, funcResult);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this Result<TIn> current,
        Func<BindResult<TIn>, Result<TOut>> func,
        Func<Exception, ValueTask<Result<TOut>>> failAsync)
    {
        try
        {
            if (!current.IsSuccess)
            {
                return current.Fail;
            }
            
            var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
            var funcResult = func(bindParameter);
            
            if (!funcResult.IsSuccess)
            {
                return funcResult.Fail;
            }
            
            return new BindResult<TOut>(current, funcResult);
        }
        catch (Exception ex)
        {
            return await failAsync(ex).ConfigureAwait(false);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this Result<TIn> current,
        Func<BindResult<TIn>, ValueTask<Result<TOut>>> funcAsync,
        Func<Exception, ValueTask<Result<TOut>>> failAsync)
    {
        try
        {
            if (!current.IsSuccess)
            {
                return current.Fail;
            }
            
            var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
            var funcResult = await funcAsync(bindParameter).ConfigureAwait(false);
            
            if (!funcResult.IsSuccess)
            {
                return funcResult.Fail;
            }
            
            return new BindResult<TOut>(current, funcResult);
        }
        catch (Exception ex)
        {
            return await failAsync(ex).ConfigureAwait(false);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this ValueTask<Result<TIn>> currentAsync,
        Func<BindResult<TIn>, Result<TOut>> func,
        Func<Exception, Result<TOut>> fail)
    {
        try
        {
            var current = await currentAsync.ConfigureAwait(false);
            return current.TryCatch(func, fail);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this ValueTask<Result<TIn>> currentAsync,
        Func<BindResult<TIn>, ValueTask<Result<TOut>>> funcAsync,
        Func<Exception, Result<TOut>> fail)
    {
        try
        {
            var current = await currentAsync.ConfigureAwait(false);
            return await current.TryCatchAsync(funcAsync, fail).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this ValueTask<Result<TIn>> currentAsync,
        Func<BindResult<TIn>, Result<TOut>> func,
        Func<Exception, ValueTask<Result<TOut>>> failAsync)
    {
        try
        {
            var current = await currentAsync.ConfigureAwait(false);
            return await current.TryCatchAsync(func, failAsync).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return await failAsync(ex).ConfigureAwait(false);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this ValueTask<Result<TIn>> currentAsync,
        Func<BindResult<TIn>, ValueTask<Result<TOut>>> funcAsync,
        Func<Exception, ValueTask<Result<TOut>>> failAsync)
    {
        try
        {
            var current = await currentAsync.ConfigureAwait(false);
            return await current.TryCatchAsync(funcAsync, failAsync).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return await failAsync(ex).ConfigureAwait(false);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this Task<Result<TIn>> currentAsync,
        Func<BindResult<TIn>, Result<TOut>> func,
        Func<Exception, Result<TOut>> fail)
    {
        try
        {
            var current = await currentAsync.ConfigureAwait(false);
            return current.TryCatch(func, fail);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this Task<Result<TIn>> currentAsync,
        Func<BindResult<TIn>, ValueTask<Result<TOut>>> funcAsync,
        Func<Exception, Result<TOut>> fail)
    {
        try
        {
            var current = await currentAsync.ConfigureAwait(false);
            return await current.TryCatchAsync(funcAsync, fail).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this Task<Result<TIn>> currentAsync,
        Func<BindResult<TIn>, Result<TOut>> func,
        Func<Exception, ValueTask<Result<TOut>>> failAsync)
    {
        try
        {
            var current = await currentAsync.ConfigureAwait(false);
            return await current.TryCatchAsync(func, failAsync).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return await failAsync(ex).ConfigureAwait(false);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(
        this Task<Result<TIn>> currentAsync,
        Func<BindResult<TIn>, ValueTask<Result<TOut>>> funcAsync,
        Func<Exception, ValueTask<Result<TOut>>> failAsync)
    {
        try
        {
            var current = await currentAsync.ConfigureAwait(false);
            return await current.TryCatchAsync(funcAsync, failAsync).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            return await failAsync(ex).ConfigureAwait(false);
        }
    }
}
