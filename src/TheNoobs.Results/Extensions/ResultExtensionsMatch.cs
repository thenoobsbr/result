using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static TOut Match<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> success, Func<Fail, TOut> fail)
    {
        return result.IsSuccess
            ? success(result.Value)
            : fail(result.Fail!);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> currentAsync, Func<BindResult<TIn>, TOut> success, Func<Fail, TOut> fail)
    {
        var current = await currentAsync.ConfigureAwait(false);
        
        if (!current.IsSuccess)
        {
            return fail(current.Fail!);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        
        return success(bindParameter);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> currentAsync, Func<BindResult<TIn>, TOut> success, Func<Fail, TOut> fail)
    {
        var current = await currentAsync.ConfigureAwait(false);

        if (!current.IsSuccess)
        {
            return fail(current.Fail!);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        
        return success(bindParameter);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> currentAsync, Func<TIn, ValueTask<TOut>> successAsync, Func<Fail, TOut> fail)
    {
        var current = await currentAsync.ConfigureAwait(false);
        
        if (!current.IsSuccess)
        {
            return fail(current.Fail!);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        
        return await successAsync(bindParameter);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> currentAsync, Func<BindResult<TIn>, TOut> success, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        
        if (!current.IsSuccess)
        {
            return await failAsync(current.Fail!);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        
        return success(bindParameter);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> currentAsync, Func<BindResult<TIn>, ValueTask<TOut>> successAsync, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        
        if (!current.IsSuccess)
        {
            return await failAsync(current.Fail!);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        
        return await successAsync(bindParameter);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> currentAsync, Func<BindResult<TIn>, Task<TOut>> successAsync, Func<Fail, TOut> fail)
    {
        var current = await currentAsync.ConfigureAwait(false);
        
        if (!current.IsSuccess)
        {
            return fail(current.Fail!);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        
        return await successAsync(bindParameter).ConfigureAwait(false);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> currentAsync, Func<BindResult<TIn>, TOut> success, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        
        if (!current.IsSuccess)
        {
            return await failAsync(current.Fail!).ConfigureAwait(false);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        
        return current.IsSuccess
            ? success(bindParameter)
            : await failAsync(current.Fail!);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> currentAsync, Func<BindResult<TIn>, ValueTask<TOut>> successAsync, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var current = await currentAsync.ConfigureAwait(false);
        
        if (!current.IsSuccess)
        {
            return await failAsync(current.Fail!).ConfigureAwait(false);
        }
        
        var bindParameter = current as BindResult<TIn> ?? new BindResult<TIn>(null, current);
        
        return await successAsync(bindParameter).ConfigureAwait(false);
    }
}
