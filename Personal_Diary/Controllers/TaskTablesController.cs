using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Personal_Diary.Models;

namespace Personal_Diary.Controllers
{
    public class TaskTablesController : Controller
    {
        private Personal_DairyEntities db = new Personal_DairyEntities();

        // GET: TaskTables
        public ActionResult Index()
        {
            // Fetch data for a particular attribute (e.g., "AttributeName" is the name of the attribute)
            String str = User.Identity.GetUserName();
            var filteredData = db.TaskTables.Where(x => x.Email == str).ToList();

            return View(filteredData);
        }

        // GET: TaskTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskTable taskTable = db.TaskTables.Find(id);
            if (taskTable == null)
            {
                return HttpNotFound();
            }
            return View(taskTable);
        }

        // GET: TaskTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Task")] TaskTable taskTable)
        {
            if (ModelState.IsValid)
            {
                DateTime currentDate = DateTime.Now.Date;
                taskTable.Date = currentDate.ToString("yyyy-MM-dd");
                taskTable.Email = User.Identity.GetUserName();
                db.TaskTables.Add(taskTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskTable);
        }

        // GET: TaskTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskTable taskTable = db.TaskTables.Find(id);
            if (taskTable == null)
            {
                return HttpNotFound();
            }
            return View(taskTable);
        }

        // POST: TaskTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Task")] TaskTable taskTable)
        {
            if (ModelState.IsValid)
            {
                DateTime currentDate = DateTime.Now.Date;
                taskTable.Date = currentDate.ToString("yyyy-MM-dd");
                taskTable.Email = User.Identity.GetUserName();
                db.Entry(taskTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskTable);
        }

        // GET: TaskTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskTable taskTable = db.TaskTables.Find(id);
            if (taskTable == null)
            {
                return HttpNotFound();
            }
            return View(taskTable);
        }

        // POST: TaskTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskTable taskTable = db.TaskTables.Find(id);
            db.TaskTables.Remove(taskTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
