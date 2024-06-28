using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<T> Catch<T, TFail>(
        this Result<T> current,
        Func<TFail, Result<T>> fail)
        where TFail : Fail
    {
        if (current.IsSuccess)
        {
            return current;
        }
        
        if (current.Fail is TFail failResult)
        {
            return fail(failResult);
        }

        return current;
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this Result<T> current,
        Func<TFail,ValueTask<Result<T>>> failAsync)
        where TFail : Fail
    {
        if (current.IsSuccess)
        {
            return current;
        }
        
        if (current.Fail is TFail failResult)
        {
            return await failAsync(failResult).ConfigureAwait(false);
        }

        return current;
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this ValueTask<Result<T>> currentAsync,
        Func<TFail, Result<T>> fail)
        where TFail : Fail
    {
        var current = await currentAsync.ConfigureAwait(false);
        return current.Catch(fail);
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this ValueTask<Result<T>> currentAsync,
        Func<TFail, ValueTask<Result<T>>> failAsync)
        where TFail : Fail
    {
        var current = await currentAsync.ConfigureAwait(false);
        return await current.CatchAsync(failAsync).ConfigureAwait(false);
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this Task<Result<T>> currentAsync,
        Func<TFail, Result<T>> fail)
        where TFail : Fail
    {
        var current = await currentAsync.ConfigureAwait(false);
        return current.Catch(fail);
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this Task<Result<T>> currentAsync,
        Func<TFail, ValueTask<Result<T>>> failAsync)
        where TFail : Fail
    {
        var current = await currentAsync.ConfigureAwait(false);
        return await current.CatchAsync(failAsync).ConfigureAwait(false);
    }
}
