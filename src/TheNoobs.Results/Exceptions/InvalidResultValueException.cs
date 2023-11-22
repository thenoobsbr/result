#if NET6_0 || NET7_0
using System.Runtime.Serialization;
#endif

namespace TheNoobs.Results.Exceptions;

[Serializable]
public sealed class InvalidResultValueException : Exception
{
    public InvalidResultValueException() : base("The result is not success, so it does not have a value.")
    {
    }

    #if NET6_0 || NET7_0
    private InvalidResultValueException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
    
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
    #endif
}
