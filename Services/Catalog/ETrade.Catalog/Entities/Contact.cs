﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ETrade.Catalog.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime  SenDate { get; set; }
    }
}
