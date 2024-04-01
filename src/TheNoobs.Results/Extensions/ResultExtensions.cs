namespace TheNoobs.Results.Extensions;

public static class ResultExtensions
{
    public static Result<TTarget> Map<TValue, TTarget>(this Result<TValue> result, Func<TValue, Result<TTarget>> map)
        where TValue: notnull
        where TTarget : notnull
    {
        if (!result.IsSuccess)
        {
            return new Result<TTarget>(result.Fail!);
        }

        return map(result.Value);
    }
    
    public static async ValueTask<Result<TTarget>> MapAsync<TValue, TTarget>(this ValueTask<Result<TValue>> result, Func<TValue, ValueTask<Result<TTarget>>> map)
        where TValue: notnull
        where TTarget : notnull
    {
        var firstResult = await result.ConfigureAwait(false);
        if (!firstResult.IsSuccess)
        {
            return new Result<TTarget>(firstResult.Fail!);
        }

        return await map(firstResult.Value).ConfigureAwait(false);
    }
}
