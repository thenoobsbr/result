using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Types;

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

    public static MergeResult Merge<TValue>(this ICollection<Result<TValue>> results)
    {
        if (results.Any(x => !x.IsSuccess))
        {
            return new AggregateFail(results.Where(x => !x.IsSuccess).Select(x => x.Fail).ToArray());
        }
        
        return new MergeResult(results.Cast<IResult>().ToArray());
    }
    
    public static Result<IReadOnlyCollection<TTargetValue>> Merge<TValue, TTargetValue>(this ICollection<Result<TValue>> results, Func<Result<TValue>, TTargetValue> map)
    {
        if (results.Any(x => !x.IsSuccess))
        {
            return new AggregateFail(results.Where(x => !x.IsSuccess).Select(x => x.Fail).ToArray());
        }
        
        return new Result<IReadOnlyCollection<TTargetValue>>(results.Select(map).ToList());
    }
}
