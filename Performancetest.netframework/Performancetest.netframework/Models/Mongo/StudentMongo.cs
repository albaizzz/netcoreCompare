using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Performancetest.netframework.Models.Mongo
{
    public class StudentMongo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("StudentId")]
        public string StudentId { get; set; }
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