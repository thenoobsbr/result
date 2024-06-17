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
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, TOut> success, Func<Fail, TOut> fail)
    {
        var result = await resultAsync.ConfigureAwait(false);
        return result.IsSuccess
            ? success(result.Value)
            : fail(result.Fail!);
    }
    
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> resultAsync, Func<TIn, TOut> success, Func<Fail, TOut> fail)
    {
        var result = await resultAsync.ConfigureAwait(false);
        return result.IsSuccess
            ? success(result.Value)
            : fail(result.Fail!);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, ValueTask<TOut>> successAsync, Func<Fail, TOut> fail)
    {
        var result = await resultAsync.ConfigureAwait(false);
        return result.IsSuccess
            ? await successAsync(result.Value)
            : fail(result.Fail!);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, TOut> success, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var result = await resultAsync.ConfigureAwait(false);
        return result.IsSuccess
            ? success(result.Value)
            : await failAsync(result.Fail!);
    }
    
    public static async ValueTask<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, ValueTask<TOut>> successAsync, Func<Fail, ValueTask<TOut>> failAsync)
    {
        var result = await resultAsync.ConfigureAwait(false);
        return result.IsSuccess
            ? await successAsync(result.Value)
            : await failAsync(result.Fail!);
    }
    
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> resultAsync, Func<TIn, Task<TOut>> successAsync, Func<Fail, TOut> fail)
    {
        var result = await resultAsync.ConfigureAwait(false);
        return result.IsSuccess
            ? await successAsync(result.Value)
            : fail(result.Fail!);
    }
    
    public static async Task<TOut> MatchAsync<TIn, TOut>(this ValueTask<Result<TIn>> resultAsync, Func<TIn, TOut> success, Func<Fail, Task<TOut>> failAsync)
    {
        var result = await resultAsync.ConfigureAwait(false);
        return result.IsSuccess
            ? success(result.Value)
            : await failAsync(result.Fail!);
    }
    
    public static async Task<TOut> MatchAsync<TIn, TOut>(this Task<Result<TIn>> resultAsync, Func<TIn, Task<TOut>> successAsync, Func<Fail, Task<TOut>> failAsync)
    {
        var result = await resultAsync.ConfigureAwait(false);
        return result.IsSuccess
            ? await successAsync(result.Value)
            : await failAsync(result.Fail!);
    }
}
