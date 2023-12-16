namespace ParcelLocker.Shared.Abstractions.TextSerializer;

public interface ITextSerializer
{
    byte[] Serialize(object objectToSerialize);
    public object Deserialize(byte[] stringToDeserialize, Type targetType);
}
