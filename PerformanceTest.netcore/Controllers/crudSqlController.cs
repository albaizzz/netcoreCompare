using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PerformanceTest.netcore.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using System.Data.SqlClient;

namespace PerformanceTest.netcore.Controllers
{
    public class crudSqlController : Controller
    {
        IConfiguration Configuration;
        DBContext _ctx;
        public crudSqlController(IConfiguration iconfiguration, DBContext DBContext)
        {
            Configuration = iconfiguration;
            _ctx = DBContext;
        }

        public IActionResult Index()
        {
            var startPeriod = DateTime.Now;

            for (int i = 0; i < 1000; i++)
            {
                _ctx.Students.Add(CreateDataStudent());
                _ctx.SaveChanges();
            }
            _ctx.SaveChanges();

            var endPeriod = DateTime.Now;
            var period = endPeriod.Subtract(startPeriod).TotalSeconds;
            ViewBag.config = Configuration.GetSection("Data").Value;
            
            using( SqlConnection con = new SqlConnection(Configuration.GetConnectionString("SQLServerConnection")))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = string.Format("exec usp_Insert_TrackingSQL '{0}', '{1}', '{2}', '{3}','{4}',{5}", "nginx", "linux", "create", startPeriod, endPeriod, period);
                    command.ExecuteNonQuery();
                }
                con.Close();
            } 
            return View(ViewBag);
        }

        public IActionResult UpdateData()
        {
            var startPeriod = DateTime.Now;
            for (int i = 1; i <= 1000; i++)
            { 
                var ranStr = Guid.NewGuid().ToString("N");
                var std = _ctx.Students.Find(i);
                std.Email = "Email-" + ranStr;
                std.FirstName = "FirstName-" + ranStr;
                std.LastName = "LastName-" + ranStr;
                std.Gender = "Gender-" + ranStr;
                std.IPAddress = "IPAddress-" + ranStr;
                _ctx.SaveChanges();
            }
            var endPeriod = DateTime.Now;
            var period = endPeriod.Subtract(startPeriod).TotalSeconds;
            
            using( SqlConnection con = new SqlConnection(Configuration.GetConnectionString("SQLServerConnection")))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = string.Format("exec usp_Insert_TrackingSQL '{0}', '{1}', '{2}', '{3}','{4}',{5}", "nginx", "linux", "update", startPeriod, endPeriod, period);
                    command.ExecuteNonQuery();
                }
                con.Close();
            } 
            cleanupData();
            return View();
        }

        private void cleanupData()
        {
            using( SqlConnection con = new SqlConnection(Configuration.GetConnectionString("SQLServerConnection")))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "truncate table student";
                    command.ExecuteNonQuery();
                }
                con.Close();
            } 
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        private StudentSQL CreateDataStudent()
        {
            var ranStr = Guid.NewGuid().ToString("N");
            return new StudentSQL()
            {
                Email = "Email-" + ranStr,
                FirstName = "FirstName-" + ranStr,
                LastName = "LastName-" + ranStr,
                Gender = "Gender-" + ranStr,
                IPAddress = "IPAddress-" + ranStr
            };
        }
    }
}
