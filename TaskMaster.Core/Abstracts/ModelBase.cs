using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TaskMaster.Core.Interfaces;

namespace TaskMaster.Core.Abstracts;

public class ModelBase : IModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public bool IsActive { get; set; } = true;

}
