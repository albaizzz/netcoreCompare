using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PerformanceTest.netcore.Models
{
    public class StudentMongo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("StudentId")]
        public int StudentId { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Gender")]
        public string Gender { get; set; }
        [BsonElement("IPAddress")]
        public string IPAddress { get; set; }

    }
}