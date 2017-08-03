using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerformanceTest.netcore.Models;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Core;


namespace PerformanceTest.netcore.Controllers
{
    public class crudMongoController : Controller
    {
        private readonly StudentMongoCruds _context = null;
        private readonly DataAccessMongo dam = null;
        IConfiguration Configuration;
        public crudMongoController(IOptions<Settings> Setting, IConfiguration iconfiguration)
        {
            _context = new StudentMongoCruds(Setting);
            dam = new DataAccessMongo(Setting);
            Configuration = iconfiguration;
        }
        public IActionResult Index()
        {
            NewMethod();
            return View();
        }

        public IActionResult Update()
        {
            var startPeriod = DateTime.Now;
            var collection =  dam._database.GetCollection<BsonDocument>("Student");
            for (int i = 0; i <= 1000; i++)
            {
                var ranStr = Guid.NewGuid().ToString("N");
                var builder = MongoDB.Driver.Builders<BsonDocument>.Filter;
                var filter = builder.Eq("StudentId", i);
                var update = MongoDB.Driver.Builders<BsonDocument>.Update
                    .Set("Email", "Email-" + ranStr);
                collection.UpdateManyAsync(filter, update);
            }
            
             var endPeriod = DateTime.Now;
            var period = endPeriod.Subtract(startPeriod).TotalSeconds;
            using( SqlConnection con = new SqlConnection(Configuration.GetConnectionString("SQLServerConnection")))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = string.Format("exec usp_Insert_TrackingMongo '{0}', '{1}', '{2}', '{3}','{4}',{5}", "nginx", "linux", "update", startPeriod, endPeriod, period);
                    command.ExecuteNonQuery();
                }
                con.Close();
            }

            for (int i = 0; i <= 1000; i++)
            {
                var ranStr = Guid.NewGuid().ToString("N");
                var builder = MongoDB.Driver.Builders<BsonDocument>.Filter;
                var filter = builder.Eq("StudentId", i);
                collection.DeleteOne(filter);
            }
             
            return View();
        }

        private void NewMethod()
        {
            var startPeriod = DateTime.Now;
            for (int i = 0; i < 1000; i++)
            {
              _context.AddStudent(GenerateData(i));  
            } 

             var endPeriod = DateTime.Now;
            var period = endPeriod.Subtract(startPeriod).TotalSeconds;
            using( SqlConnection con = new SqlConnection(Configuration.GetConnectionString("SQLServerConnection")))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = string.Format("exec usp_Insert_TrackingMongo '{0}', '{1}', '{2}', '{3}','{4}',{5}", "nginx", "linux", "create", startPeriod, endPeriod, period);
                    command.ExecuteNonQuery();
                }
                con.Close();
            } 
        }

        private StudentMongo GenerateData(int idx)
        {
            var ranStr = Guid.NewGuid().ToString("N");
            return new StudentMongo()
            {
                StudentId = idx,
                Email = "Email-" + ranStr,
                FirstName = "FirstName-" + ranStr,
                LastName = "LastName-" + ranStr,
                Gender = "Gender-" + ranStr,
                IPAddress = "IPAddress-" + ranStr
            };
        }
    }
}