using TheNoobs.Results.Types;
using Void = TheNoobs.Results.Types.Void;

namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<T> Tap<T>(this Result<T> current, Func<BindResult<T>, Result<Void>> action)
    {
        if (!current.IsSuccess)
        {
            return current.Fail!;
        }

        var bindParameter = current as BindResult<T> ?? new BindResult<T>(null, current);
        
        var actionResult = action(bindParameter);
        if (!actionResult.IsSuccess)
        {
            return actionResult.Fail!;
        }

        return current;
    }
    
    public static async ValueTask<Result<T>> TapAsync<T>(this Result<T> current, Func<BindResult<T>, ValueTask<Result<Void>>> action)
    {
        if (!current.IsSuccess)
        {
            return current.Fail!;
        }

        var bindParameter = current as BindResult<T> ?? new BindResult<T>(null, current);
        var actionResult = await action(bindParameter).ConfigureAwait(false);
        if (!actionResult.IsSuccess)
        {
            return actionResult.Fail!;
        }

        return current;
    }
    
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> currentAsync, Func<BindResult<T>, Result<Void>> action)
    {
        var current = await currentAsync.ConfigureAwait(false);
        if (!current.IsSuccess)
        {
            return current.Fail!;
        }
        
        var bindParameter = current as BindResult<T> ?? new BindResult<T>(null, current);
        var actionResult = action(bindParameter);
        
        if (!actionResult.IsSuccess)
        {
            return actionResult.Fail!;
        }
        
        return current;
    }
    
    public static async ValueTask<Result<T>> TapAsync<T>(this ValueTask<Result<T>> currentAsync, Func<BindResult<T>, ValueTask<Result<Void>>> actionAsync)
    {
        var current = await currentAsync.ConfigureAwait(false); 
        if (!current.IsSuccess)
        {
            return current.Fail!;
        }
        
        var bindParameter = current as BindResult<T> ?? new BindResult<T>(null, current);
        var actionResult = await actionAsync(bindParameter).ConfigureAwait(false);
        
        if (!actionResult.IsSuccess)
        {
            return actionResult.Fail!;
        }

        return current;
    }
    
    public static async ValueTask<Result<T>> TapAsync<T>(this Task<Result<T>> currentAsync, Func<BindResult<T>, Result<Void>> action)
    {
        var current = await currentAsync.ConfigureAwait(false); 
        if (!current.IsSuccess)
        {
            return current.Fail!;
        }
        
        var bindParameter = current as BindResult<T> ?? new BindResult<T>(null, current);
        var actionResult = action(bindParameter);
        
        if (!actionResult.IsSuccess)
        {
            return actionResult.Fail!;
        }

        return current;
    }
    
    public static async ValueTask<Result<T>> TapAsync<T>(this Task<Result<T>> currentAsync, Func<BindResult<T>, ValueTask<Result<Void>>> actionAsync)
    {
        var current = await currentAsync.ConfigureAwait(false); 
        if (!current.IsSuccess)
        {
            return current.Fail!;
        }
        
        var bindParameter = current as BindResult<T> ?? new BindResult<T>(null, current);
        var actionResult = await actionAsync(bindParameter).ConfigureAwait(false);
        
        if (!actionResult.IsSuccess)
        {
            return actionResult.Fail!;
        }

        return current;
    }
}
