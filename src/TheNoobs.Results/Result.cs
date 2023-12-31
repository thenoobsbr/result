﻿using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Exceptions;
using TheNoobs.Results.Types;

namespace TheNoobs.Results;

public sealed record Result<T> : IResult where T : notnull
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

    object IResult.GetValue() => Value;

    public static implicit operator T(Result<T> result)
    {
        return result.Value;
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(value);
    }
    
    public static implicit operator Result<T>(Fail fail)
    {
        return new Result<T>(fail);
    }
    
    public static Result<T> operator &(IResult left, Result<T> right)
    {
        return !left.IsSuccess ? left.Fail! : right;
    }

    public static Result<Types.Void> operator |(Result<T> left, IResult right) => Combine(left, right);
    
    public Result<TValue> GetValueWhenSuccess<TValue>(Func<TValue> getValue)
        where TValue : notnull
    {
        return IsSuccess ? getValue() : Fail!;
    }

    public void Deconstruct(out T? value, out Fail? fail)
    {
        value = Value;
        fail = Fail;
    }
    
    private static Result<Types.Void> Combine(IResult left, IResult right)
    {
        if (left.IsSuccess && right.IsSuccess)
        {
            return new Result<Types.Void>(new Types.Void());
        }

        if (left.Fail is null || right.Fail is null)
        {
            return new Result<Types.Void>(left.Fail ?? right.Fail!);
        }

        var leftFailures = GetFailures(left.Fail);
        var rightFailures = GetFailures(right.Fail);
        var failures = leftFailures.Concat(rightFailures).ToArray();
        var resultFail = new AggregateFail(failures);
        return new Result<Types.Void>(resultFail);

        IEnumerable<Fail> GetFailures(Fail fail)
        {
            if (fail is AggregateFail aggregateFail)
            {
                return aggregateFail.Failures;
            }

            return new [] { fail };
        }
    }
}
