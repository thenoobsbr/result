using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Types;

namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<(T1, T2)> Merge<T1, T2>(this Result<T1> result, Result<T2> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2)>((
            result.Value,
            other.Value));
    }
    
    public static Result<(T1, T2, T3)> Merge<T1, T2, T3>(this Result<(T1, T2)> result, Result<T3> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2, T3)>((
            result.Value.Item1,
            result.Value.Item2,
            other.Value));
    }
    
    public static MergeResult Merge<TValue>(this Result<TValue> result, params IResult[] others)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (others.Any(x => !x.IsSuccess))
        {
            return new AggregateFail(others.Where(x => !x.IsSuccess).Select(x => x.Fail!).ToArray());
        }

        return new MergeResult([
            result,
            ..others
        ]);
    }
}
