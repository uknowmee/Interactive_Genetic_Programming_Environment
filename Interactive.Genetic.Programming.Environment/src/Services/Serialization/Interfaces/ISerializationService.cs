using Shared.Interfaces;

namespace Serialization.Interfaces;

public interface ISerializationService
{
    object DeserializeTo<T>(string csvContent) where T : ICsvSerializable;
    string? Serialize<T>(T csvSerializable) where T : ICsvSerializable;
}