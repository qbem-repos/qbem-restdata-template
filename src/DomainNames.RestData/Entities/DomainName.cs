using MongoDB.Bson.Serialization.Attributes;
using QBem.RestData.Toolkit.Domain.Abstractions;

namespace DomainNames.WebApi;

[BsonIgnoreExtraElements]
public record DomainName() : Entity()
{
}
