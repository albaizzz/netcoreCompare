using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Performancetest.netframework.Models.SQL;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Performancetest.netframework.Controllers
{
    public class CrudSQLController : Controller
    {
        //
        // GET: /CrudSQL/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CrudSQL/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateData()
        {
            var startPeriod = DateTime.Now;
            DBContextSql ctx = new DBContextSql();
            for (int i = 0; i < 50; i++)
            {
                ctx.Students.Add(CreateDataStudent());
                ctx.SaveChanges();
            }
            var endPeriod = DateTime.Now;
            var period = endPeriod.Subtract(startPeriod).TotalSeconds;
            ctx.Database.ExecuteSqlCommand("exec usp_Insert_TrackingSQL @p0, @p1, @p2, @p3, @p4, @p5", "nginx", "linux", "create", startPeriod, endPeriod, period);
            return View();
        }


        public ActionResult UpdateData()
        {
            var startPeriod = DateTime.Now;
            DBContextSql ctx = new DBContextSql();
            for (int i = 1; i <= 1000; i++)
            { 
                var ranStr = Guid.NewGuid().ToString("N");
                var std = ctx.Students.Find(i);
                std.Email = "Email-" + ranStr;
                std.FirstName = "FirstName-" + ranStr;
                std.LastName = "LastName-" + ranStr;
                std.Gender = "Gender-" + ranStr;
                std.IPAddress = "IPAddress-" + ranStr;
                ctx.SaveChanges();
            }
            var endPeriod = DateTime.Now;
            var period = endPeriod.Subtract(startPeriod).TotalSeconds;
            ctx.Database.ExecuteSqlCommand("exec usp_Insert_TrackingSQL @p0, @p1, @p2, @p3, @p4, @p5", "nginx", "linux", "update", startPeriod, endPeriod, period);
            return View();
        }

        //
        // GET: /CrudSQL/Create
        public ActionResult Create()
        {

            return View();
        }

        //
        // POST: /CrudSQL/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CrudSQL/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CrudSQL/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /CrudSQL/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CrudSQL/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
