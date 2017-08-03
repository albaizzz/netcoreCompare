using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Options;

namespace PerformanceTest.netcore.Models
{
    public class DataAccessMongo
    {
        public readonly IMongoDatabase _database = null;

        public DataAccessMongo(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<StudentMongo> Students
        {
            get
            {
                return _database.GetCollection<StudentMongo>("Student");
            }
        }
    }

    
}