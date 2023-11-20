namespace TheNoobs.Results;

public sealed record Result<T> where T : notnull
{
    public Result(T value)
    {
        Fail = null;
        Value = value;
        IsSuccess = true;
    }

    public Result(Fail fail)
    {
        Fail = fail;
        Value = default!;
        IsSuccess = false;
    }
    
    public T Value { get; }
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
