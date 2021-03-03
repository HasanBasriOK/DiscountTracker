using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class BaseEntity
    {
        [BsonId]
        public string Id { get; set; }
    }
}
