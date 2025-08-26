using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Types;
using Void = TheNoobs.Results.Types.Void;

namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static MergeResult Merge<TValue>(
        this Result<TValue> result,
        params IResult[] others)
    {
        if (!result.IsSuccess)
        {
            return result.Fail;
        }
        
        if (others.Any(x => !x.IsSuccess))
        {
            return new AggregateFail(others.Where(x => !x.IsSuccess).Select(x => x.Fail).ToArray());
        }

        return new MergeResult([
            result,
            ..others
        ]);
    }

    public static MergeResult Merge<TValue>(this IEnumerable<Result<TValue>> results)
    {
        var resultItems = results.ToList();
        var failures = resultItems.Where(x => !x.IsSuccess).Select(x => x.Fail).ToArray();
        if (failures.Length > 0)
        {
            return new AggregateFail(failures);
        }
        return new MergeResult(resultItems.Cast<IResult>().ToArray());
    }
    
    public static Result<IReadOnlyCollection<TTargetValue>> Merge<TValue, TTargetValue>(this ICollection<Result<TValue>> results, Func<Result<TValue>, TTargetValue> map)
    {
        if (results.Any(x => !x.IsSuccess))
        {
            return new AggregateFail(results.Where(x => !x.IsSuccess).Select(x => x.Fail).ToArray());
        }
        
        return new Result<IReadOnlyCollection<TTargetValue>>(results.Select(map).ToList());
    }

    public static ValueTask<MergeResult> MergeAsync<T>(this IEnumerable<ValueTask<Result<T>>> results)
    {
        return results.Select(x => x.AsTask()).MergeAsync();
    }
    
    public static async ValueTask<MergeResult> MergeAsync<T>(this IEnumerable<Task<Result<T>>> results)
    {
        var resultItems = results.ToList();
        var syncResults = new List<Result<T>>(resultItems.Count);
        foreach (var resultItem in resultItems)
        {
            var result = await resultItem;
            syncResults.Add(result);
        }
        return syncResults.Merge();
    }
}
