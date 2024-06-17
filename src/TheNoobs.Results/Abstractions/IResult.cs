namespace TheNoobs.Results.Abstractions;

public interface IResult
{
    bool IsSuccess { get; }
    Fail? Fail { get; }
    object? GetValue();
}
