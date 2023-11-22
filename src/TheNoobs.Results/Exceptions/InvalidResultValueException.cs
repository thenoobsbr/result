using System.Runtime.Serialization;

namespace TheNoobs.Results.Exceptions;

[Serializable]
public class InvalidResultValueException : Exception
{
    public InvalidResultValueException() : base("The result is not success, so it does not have a value.")
    {
    }

    #if NET6_0 || NET7_0
    public InvalidResultValueException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
    #endif
}
