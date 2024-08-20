using MongoDB.Bson.Serialization.Attributes;
using QBem.RestData.Toolkit.Domain.Abstractions;

namespace WebApi.Entities;

[BsonIgnoreExtraElements]
public record MyEntity() : Entity()
{
}
