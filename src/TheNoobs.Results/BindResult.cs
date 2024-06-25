using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Types;

namespace TheNoobs.Results;

public record BindResult<TValue> : Result<TValue>, IBindResult
{
    internal BindResult(IBindResult? current, TValue next) : base(next)
    {
        Previous = current;
    }
    
    internal BindResult(Fail fail) : base(fail)
    {
        Previous = null!;
    }
    
    private IBindResult? Previous { get; }
    
    public static implicit operator BindResult<TValue>(TValue value)
    {
        return new BindResult<TValue>(null, value);
    }
    
    public static implicit operator BindResult<TValue>(Fail fail)
    {
        return new BindResult<TValue>(fail);
    }

    public Result<TInnerValue> GetValue<TInnerValue>()
    {
        if (typeof(TValue) == typeof(TInnerValue))
        {
            return new Result<TInnerValue>((TInnerValue)(object)Value!);
        }

        return Previous?.GetValue<TInnerValue>() ?? new NotFoundFail("Value not found");
    }
}
