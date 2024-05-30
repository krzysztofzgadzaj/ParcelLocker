using System.Text;
using System.Text.Json;
using OutPost.Shared.Abstractions.TextSerializer;

namespace OutPost.Shared.Infrastructure.TextSerializer;

internal class TextSerializer : ITextSerializer
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public string Serialize(object objectToSerialize)
        => JsonSerializer.Serialize(objectToSerialize, SerializerOptions);
    
    public byte[] SerializeToByteArray(object objectToSerialize)
        => Encoding.UTF8.GetBytes(Serialize(objectToSerialize));

    public T Deserialize<T>(string stringToDeserialize) 
        => JsonSerializer.Deserialize<T>(stringToDeserialize);

    public object Deserialize(byte[] stringToDeserialize, Type targetType)
        => JsonSerializer.Deserialize(Encoding.UTF8.GetString(stringToDeserialize), targetType, SerializerOptions);
}
