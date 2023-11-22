using System.Runtime.Serialization;

namespace TheNoobs.Results.Exceptions;

[Serializable]
public class InvalidResultValueException()
    : Exception("Invalid result value, the IsSuccess property should be checked before hand.")
{
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }
}
