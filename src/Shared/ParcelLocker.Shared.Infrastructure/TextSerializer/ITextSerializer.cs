namespace ParcelLocker.Shared.Infrastructure.TextSerializer;

public interface ITextSerializer
{
    byte[] Serialize(object objectToSerialize);
    public object Deserialize(byte[] stringToDeserialize, Type targetType);
}