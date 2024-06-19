namespace TheNoobs.Results.Extensions;

public static partial class ResultExtensions
{
    public static Result<(T1, T2)> Merge<T1, T2>(this Result<T1> result, Result<T2> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2)>((
            result.Value,
            other.Value));
    }
    
    public static Result<(T1, T2, T3)> Merge<T1, T2, T3>(this Result<(T1, T2)> result, Result<T3> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2, T3)>((
            result.Value.Item1,
            result.Value.Item2,
            other.Value));
    }
    
    public static Result<(T1, T2, T3, T4)> Merge<T1, T2, T3, T4>(this Result<(T1, T2, T3)> result, Result<T4> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2, T3, T4)>((
            result.Value.Item1,
            result.Value.Item2,
            result.Value.Item3,
            other.Value));
    }
    
    public static Result<(T1, T2, T3, T4, T5)> Merge<T1, T2, T3, T4, T5>(this Result<(T1, T2, T3, T4)> result, Result<T5> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2, T3, T4, T5)>((
            result.Value.Item1,
            result.Value.Item2,
            result.Value.Item3,
            result.Value.Item4,
            other.Value));
    }
    
    public static Result<(T1, T2, T3, T4, T5, T6)> Merge<T1, T2, T3, T4, T5, T6>(this Result<(T1, T2, T3, T4, T5)> result, Result<T6> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2, T3, T4, T5, T6)>((
            result.Value.Item1,
            result.Value.Item2,
            result.Value.Item3,
            result.Value.Item4,
            result.Value.Item5,
            other.Value));
    }
    
    public static Result<(T1, T2, T3, T4, T5, T6, T7)> Merge<T1, T2, T3, T4, T5, T6, T7>(this Result<(T1, T2, T3, T4, T5, T6)> result, Result<T7> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2, T3, T4, T5, T6, T7)>((
            result.Value.Item1,
            result.Value.Item2,
            result.Value.Item3,
            result.Value.Item4,
            result.Value.Item5,
            result.Value.Item6,
            other.Value));
    }
    
    public static Result<(T1, T2, T3, T4, T5, T6, T7, T8)> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Result<(T1, T2, T3, T4, T5, T6, T7)> result, Result<T8> other)
    {
        if (!result.IsSuccess)
        {
            return result.Fail!;
        }
        
        if (!other.IsSuccess)
        {
            return other.Fail!;
        }
        
        return new Result<(T1, T2, T3, T4, T5, T6, T7, T8)>((
            result.Value.Item1,
            result.Value.Item2,
            result.Value.Item3,
            result.Value.Item4,
            result.Value.Item5,
            result.Value.Item6,
            result.Value.Item7,
            other.Value));
    }
}
