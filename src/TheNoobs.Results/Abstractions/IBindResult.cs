namespace TheNoobs.Results.Abstractions;

public interface IBindResult
{
    Result<TValue> GetValue<TValue>();
}
