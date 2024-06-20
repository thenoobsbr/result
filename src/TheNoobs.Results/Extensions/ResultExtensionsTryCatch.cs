namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<TOut> TryCatch<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func, Func<Exception, Result<TOut>> fail)
    {
        try
        {
            return result.IsSuccess
                ? new Result<TOut>(func(result.Value))
                : result.Fail!;
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(this Result<TIn> result, Func<TIn, ValueTask<TOut>> funcAsync, Func<Exception, Result<TOut>> fail)
    {
        try
        {
            if (!result.IsSuccess)
            {
                return result.Fail!;
            }

            return await funcAsync(result);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<TOut>> funcAsync, Func<Exception, Result<TOut>> fail)
    {
        try
        {
            if (!result.IsSuccess)
            {
                return result.Fail!;
            }

            return await funcAsync(result);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, TOut> func, Func<Exception, Result<TOut>> fail)
    {
        try
        {
            var result = await resultAsync.ConfigureAwait(false);
            return TryCatch(result, func, fail);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async Task<Result<TOut>> TryCatchAsync<TIn, TOut>(this Task<Result<TIn>> resultAsync, Func<TIn, TOut> func, Func<Exception, Result<TOut>> fail)
    {
        try
        {
            var result = await resultAsync.ConfigureAwait(false);
            return TryCatch(result, func, fail);
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, ValueTask<TOut>> funcAsync, Func<Exception, Result<TOut>> fail)
    {
        try
        {
            var result = await resultAsync.ConfigureAwait(false);
            return result.IsSuccess
                ? await funcAsync(result).ConfigureAwait(false)
                : result.Fail!;
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async Task<Result<TOut>> TryCatchAsync<TIn, TOut>(this Task<Result<TIn>> resultAsync, Func<TIn, Task<TOut>> funcAsync, Func<Exception, Result<TOut>> fail)
    {
        try
        {
            var result = await resultAsync.ConfigureAwait(false);
            return result.IsSuccess
                ? await funcAsync(result).ConfigureAwait(false)
                : result.Fail!;
        }
        catch (Exception ex)
        {
            return fail(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, TOut> func, Func<Exception, ValueTask<Result<TOut>>> failAsync)
    {
        try
        {
            var result = await resultAsync.ConfigureAwait(false);
            return result.IsSuccess
                ? func(result)
                : result.Fail!;
        }
        catch (Exception ex)
        {
            return await failAsync(ex).ConfigureAwait(false);
        }
    }
    
    public static async Task<Result<TOut>> TryCatchAsync<TIn, TOut>(this Task<Result<TIn>> resultAsync, Func<TIn, TOut> func, Func<Exception, Task<Result<TOut>>> failAsync)
    {
        try
        {
            var result = await resultAsync.ConfigureAwait(false);
            return result.IsSuccess
                ? func(result)
                : result.Fail!;
        }
        catch (Exception ex)
        {
            return await failAsync(ex);
        }
    }
    
    public static async ValueTask<Result<TOut>> TryCatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, ValueTask<TOut>> funcAsync, Func<Exception, ValueTask<Result<TOut>>> failAsync)
    {
        try
        {
            var result = await resultAsync.ConfigureAwait(false);
            return result.IsSuccess
                ? await funcAsync(result).ConfigureAwait(false)
                : result.Fail!;
        }
        catch (Exception ex)
        {
            return await failAsync(ex).ConfigureAwait(false);
        }
    }
    
    public static async Task<Result<TOut>> TryCatchAsync<TIn, TOut>(this Task<Result<TIn>> resultAsync, Func<TIn, Task<TOut>> funcAsync, Func<Exception, Task<Result<TOut>>> failAsync)
    {
        try
        {
            var result = await resultAsync.ConfigureAwait(false);
            return result.IsSuccess
                ? await funcAsync(result).ConfigureAwait(false)
                : result.Fail!;
        }
        catch (Exception ex)
        {
            return await failAsync(ex);
        }
    }
}
