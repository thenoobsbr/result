using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<T> Catch<T, TFail>(
        this Result<T> result,
        Func<TFail, Result<T>> fail)
        where TFail : Fail
    {
        if (result.IsSuccess)
        {
            return result;
        }
        
        if (result.Fail is TFail failResult)
        {
            return fail(failResult);
        }

        return result;
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this ValueTask<Result<T>> resultAsync,
        Func<TFail, Result<T>> fail)
        where TFail : Fail
    {
        var result = await resultAsync.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            return result;
        }
        
        if (result.Fail is TFail failResult)
        {
            return fail(failResult);
        }

        return result;
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this ValueTask<Result<T>> resultAsync,
        Func<TFail, ValueTask<Result<T>>> failAsync)
        where TFail : Fail
    {
        var result = await resultAsync.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            return result;
        }
        
        if (result.Fail is TFail failResult)
        {
            return await failAsync(failResult).ConfigureAwait(false);
        }

        return result;
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this Result<T> result,
        Func<TFail,ValueTask<Result<T>>> failAsync)
        where TFail : Fail
    {
        if (result.IsSuccess)
        {
            return result;
        }
        
        if (result.Fail is TFail failResult)
        {
            return await failAsync(failResult).ConfigureAwait(false);
        }

        return result;
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this Task<Result<T>> resultAsync,
        Func<TFail, Result<T>> fail)
        where TFail : Fail
    {
        var result = await resultAsync.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            return result;
        }
        
        if (result.Fail is TFail failResult)
        {
            return fail(failResult);
        }

        return result;
    }
    
    public static async ValueTask<Result<T>> CatchAsync<T, TFail>(
        this Task<Result<T>> resultAsync,
        Func<TFail, ValueTask<Result<T>>> failAsync)
        where TFail : Fail
    {
        var result = await resultAsync.ConfigureAwait(false);
        if (result.IsSuccess)
        {
            return result;
        }
        
        if (result.Fail is TFail failResult)
        {
            return await failAsync(failResult).ConfigureAwait(false);
        }

        return result;
    }
}
