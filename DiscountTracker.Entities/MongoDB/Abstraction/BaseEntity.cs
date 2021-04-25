using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class BaseEntity : IEntity<string>
    {
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; set; }
        [BsonElement(Order = 99)]
        public bool IsTransferred { get; set; }

    }
}
