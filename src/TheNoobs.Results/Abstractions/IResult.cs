namespace TheNoobs.Results.Abstractions;

public interface IResult
{
    Type ResultType { get; }
    bool IsSuccess { get; }
    Fail? Fail { get; }
    object GetValue();
    T GetValue<T>();
}
