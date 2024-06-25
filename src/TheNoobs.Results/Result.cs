﻿using TheNoobs.Results.Abstractions;
using TheNoobs.Results.Exceptions;

namespace TheNoobs.Results;

public record Result<T> : IResult
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
    public Type ResultType => typeof(T);
    public bool IsSuccess { get; }
    
    public Fail? Fail { get; }

    object IResult.GetValue() => Value!;
    TValue IResult.GetValue<TValue>()
    {
        return (TValue)(object)Value!;
    }

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

    public void Deconstruct(out T? value, out Fail? fail)
    {
        value = Value;
        fail = Fail;
    }
}
