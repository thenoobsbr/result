using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Types;

namespace TheNoobs.Results;

public record MergeResult : Result<IResult[]>
{
    internal MergeResult(IResult[] value) : base(value)
    {
    }

    internal MergeResult(Fail fail) : base(fail)
    {
    }
    
    public static implicit operator MergeResult(Fail fail)
    {
        return new MergeResult(fail);
    }
    
    public override Result<TValue> GetValue<TValue>()
    {
        if (!IsSuccess)
        {
            return Fail;
        }
        
        return Value
            .FirstOrDefault(x => x.GetValue<TValue>().IsSuccess)?
            .GetValue<TValue>() ?? new NotFoundFail("Value not found");
    }
    
    public Result<TValue> GetValueByIndex<TValue>(int index)
    {
        if (!IsSuccess)
        {
            return Fail;
        }
        
        var result = Value.ElementAtOrDefault(index);
        if (result is null)
        {
            return new NotFoundFail("Value not found");
        }

        return result.GetValue<TValue>();
    }
}
