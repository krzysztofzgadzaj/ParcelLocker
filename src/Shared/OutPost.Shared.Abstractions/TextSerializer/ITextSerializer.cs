namespace OutPost.Shared.Abstractions.TextSerializer;

public interface ITextSerializer
{
    string Serialize(object objectToSerialize);
    byte[] SerializeToByteArray(object objectToSerialize);
    public T Deserialize<T>(string stringToDeserialize);
    public object Deserialize(byte[] stringToDeserialize, Type targetType);
}
