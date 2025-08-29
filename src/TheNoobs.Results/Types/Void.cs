namespace TheNoobs.Results.Types;

public readonly struct Void
{
    public static Void Value => new();
    public static implicit operator ValueTask<Result<Void>>(Void value) => ValueTask.FromResult(new Result<Void>(value));
}
