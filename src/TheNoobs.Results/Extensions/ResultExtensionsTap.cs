namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
    {
        if (result.IsSuccess)
        {
            action(result.Value);
        }

        return result;
    }
    
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> resultAsync, Action<T> action)
    {
        var result = await resultAsync.ConfigureAwait(false); 
        return Tap(result, action);
    }
    
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> resultAsync, Func<T, ValueTask> actionAsync)
    {
        var result = await resultAsync.ConfigureAwait(false); 
        if (result.IsSuccess)
        {
            await actionAsync(result.Value);
        }

        return result;
    }
    
    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultAsync, Action<T> action)
    {
        var result = await resultAsync.ConfigureAwait(false); 
        if (result.IsSuccess)
        {
            action(result.Value);
        }

        return result;
    }
    
    public static async Task<Result<T>> TapAsync<T>(this Task<Result<T>> resultAsync, Func<T, Task> actionAsync)
    {
        var result = await resultAsync.ConfigureAwait(false); 
        if (result.IsSuccess)
        {
            await actionAsync(result.Value).ConfigureAwait(false);
        }

        return result;
    }
}
