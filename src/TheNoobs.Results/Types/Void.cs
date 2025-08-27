namespace TheNoobs.Results.Types;

public readonly struct Void
{
    public static Void Value => new();
    public static implicit operator Result<Void>(Void value) => new(value);
    public static implicit operator ValueTask<Result<Void>>(Void value) => ValueTask.FromResult(new Result<Void>(value));
    public static implicit operator Task<Result<Void>>(Void value) => Task.FromResult(new Result<Void>(value));
}
