using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Types;

namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
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
