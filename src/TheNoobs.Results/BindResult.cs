using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Types;

namespace TheNoobs.Results;

public record BindResult<TValue> : Result<TValue>
{
    internal BindResult(IResult? current, TValue next) : base(next)
    {
        Previous = current;
    }
    
    internal BindResult(Fail fail) : base(fail)
    {
        Previous = null!;
    }
    
    private IResult? Previous { get; }

    public override Result<TInnerValue> GetValue<TInnerValue>()
    {
        if (typeof(TValue) == typeof(TInnerValue))
        {
            return new Result<TInnerValue>((TInnerValue)(object)Value!);
        }

        if (Value is IResult result)
        {
            return result.GetValue<TInnerValue>();
        }

        if (Value is IResult[] results)
        {
            return results.FirstOrDefault(x => x.GetValue<TInnerValue>().IsSuccess)
                ?.GetValue<TInnerValue>() ?? new NotFoundFail("Value not found");
        }

        return Previous?.GetValue<TInnerValue>() ?? new NotFoundFail("Value not found");
    }
}
