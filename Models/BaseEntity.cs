using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WokerCloud.Models
{
    public class BaseEntity
    {
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("createdAt")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdateAt { get; set; }
    }
}