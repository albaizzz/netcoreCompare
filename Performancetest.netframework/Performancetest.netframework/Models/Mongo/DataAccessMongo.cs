using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace Performancetest.netframework.Models.Mongo
{
    public class DataAccessMongo
    {
        private readonly IMongoDatabase _database = null;

        public DataAccessMongo()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["DBStrMongo"].ToString());
            if (client != null)
                _database = client.GetDatabase(ConfigurationManager.AppSettings["MongoDB"].ToString());
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