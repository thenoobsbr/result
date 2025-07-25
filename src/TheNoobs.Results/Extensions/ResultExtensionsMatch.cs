using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static TOut Match<TIn, TOut>(this Result<TIn> result, Func<BindResult<TIn>, TOut> success, Func<Fail, TOut> fail)
    {
        if (!result.IsSuccess)
        {
            return fail(result.Fail);
        }
        
        var bindParameter = result as BindResult<TIn> ?? new BindResult<TIn>(null, result);
        return success(bindParameter);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Result<TIn> current, Func<BindResult<TIn>, ValueTask<TOut>> successAsync, Func<Fail, TOut> fail)
    {
        if (!current.IsSuccess)
        {
            return fail(current.Fail);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        return await successAsync(bindParameter).ConfigureAwait(false);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Result<TIn> current, Func<BindResult<TIn>, TOut> success, Func<Fail, ValueTask<TOut>> failAsync)
    {
        if (!current.IsSuccess)
        {
            return await failAsync(current.Fail).ConfigureAwait(false);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        return success(bindParameter);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Result<TIn> current, Func<BindResult<TIn>, ValueTask<TOut>> successAsync, Func<Fail, ValueTask<TOut>> failAsync)
    {
        if (!current.IsSuccess)
        {
            return await failAsync(current.Fail).ConfigureAwait(false);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        return await successAsync(bindParameter).ConfigureAwait(false);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> currentAsync, Func<BindResult<TIn>, TOut> success, Func<Fail, TOut> fail)
    {
        var current = await currentAsync.ConfigureAwait(false);
        return current.Match(success, fail);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> currentAsync, Func<BindResult<TIn>, ValueTask<TOut>> successAsync, Func<Fail, TOut> fail)
    {
        var current = await currentAsync.ConfigureAwait(false);
        return await current.MatchAsync(successAsync, fail).ConfigureAwait(false);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> currentAsync, Func<BindResult<TIn>, TOut> success, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        return await current.MatchAsync(success, failAsync).ConfigureAwait(false);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> currentAsync, Func<BindResult<TIn>, ValueTask<TOut>> successAsync, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        return await current.MatchAsync(successAsync, failAsync).ConfigureAwait(false);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> currentAsync, Func<BindResult<TIn>, TOut> success, Func<Fail, TOut> fail)
    {
        var current = await currentAsync.ConfigureAwait(false);
        return current.Match(success, fail);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> currentAsync, Func<BindResult<TIn>, ValueTask<TOut>> successAsync, Func<Fail, TOut> fail)
    {
        var current = await currentAsync.ConfigureAwait(false);
        return await current.MatchAsync(successAsync, fail).ConfigureAwait(false);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> currentAsync, Func<BindResult<TIn>, TOut> success, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        return await current.MatchAsync(success, failAsync).ConfigureAwait(false);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> currentAsync, Func<BindResult<TIn>, ValueTask<TOut>> successAsync, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        return await current.MatchAsync(successAsync, failAsync).ConfigureAwait(false);
    }
}
