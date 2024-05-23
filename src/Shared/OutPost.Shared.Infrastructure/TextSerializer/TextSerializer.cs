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

    public byte[] Serialize(object objectToSerialize)
        => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(objectToSerialize, SerializerOptions));
    
    public object Deserialize(byte[] stringToDeserialize, Type targetType)
        => JsonSerializer.Deserialize(Encoding.UTF8.GetString(stringToDeserialize), targetType, SerializerOptions);
}
