using TheNoobs.Results.Exceptions;

namespace TheNoobs.Results;

public sealed record Result<T> where T : notnull
{
    private readonly T _value;
    
    public Result(T value)
    {
        Fail = null;
        _value = value;
        IsSuccess = true;
    }

    public Result(Fail fail)
    {
        Fail = fail;
        _value = default!;
        IsSuccess = false;
    }

    public T Value => IsSuccess ? _value : throw new InvalidResultValueException();
    public bool IsSuccess { get; }
    
    public Fail? Fail { get; }
    
    public static implicit operator T(Result<T> result)
    {
        return result.Value ?? throw new Exception();
    }

    public void Deconstruct(out T? value, out Fail? fail)
    {
        value = Value;
        fail = Fail;
    }
}
