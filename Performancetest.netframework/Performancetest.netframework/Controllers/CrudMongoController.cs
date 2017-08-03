using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Performancetest.netframework.Models.Mongo;

namespace Performancetest.netframework.Controllers
{
    public class CrudMongoController : Controller
    {
        //
        // GET: /CrudMongo/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /CrudMongo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CrudMongo/Create

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateData()
        {
            DataAccessMongo ctx = new DataAccessMongo();
            for (int i = 0; i < 1000; i++)
            {
                
                ctx.Students.InsertOneAsync(doc);
            }
            
            return View();
        }

        private StudentMongo CreateDataStudent(int idx)
        {
            var ranStr = Guid.NewGuid().ToString("N");
            return new StudentMongotMo()
            {
                StudentId = idx,
                Email = "Email-" + ranStr,
                FirstName = "FirstName-" + ranStr,
                LastName = "LastName-" + ranStr,
                Gender = "Gender-" + ranStr,
                IPAddress = "IPAddress-" + ranStr
            };
        }

        //
        // POST: /CrudMongo/Create
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
        // GET: /CrudMongo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CrudMongo/Edit/5

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
        // GET: /CrudMongo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CrudMongo/Delete/5

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
    }
}
