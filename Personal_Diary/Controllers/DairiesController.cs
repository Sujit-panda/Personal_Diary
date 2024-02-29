using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Personal_Diary.Models;

namespace Personal_Dairy.Controllers
{
    public class DairiesController : Controller
    {
        private Personal_DairyEntities db = new Personal_DairyEntities();

        // GET: Dairies
        public ActionResult Index()
        {
            var email_data = User.Identity.GetUserName();
            var filteredData = db.Dairies.Where(x => x.Email == email_data).ToList();
            return View(filteredData);

        }

        // GET: Dairies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dairy dairy = db.Dairies.Find(id);
            if (dairy == null)
            {
                return HttpNotFound();
            }
            return View(dairy);
        }
        //**************************************
        // GET: Dairies/Create
        public ActionResult Create()
        {
            String email = User.Identity.GetUserName();
            DateTime currentDate = DateTime.Now.Date;
            String cDate = currentDate.ToString("yyyy-MM-dd");
            if (db.Dairies.Any(x => x.Date == cDate) && db.Dairies.Any(x => x.Email == email))
            {
                
                var filteredData = db.Dairies.Where(x => x.Date == cDate && x.Email == email).Select(x => x.id).FirstOrDefault();
                if (filteredData == 0)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Edit", new { id = filteredData });
                }
            }
            else if(db.Dairies.Any(x => x.Date != cDate) && db.Dairies.Any(x => x.Date == cDate) && db.Dairies.Any(x => x.Email == email) )
            {
               /* var filteredData = db.Dairies.Where(x => x.Date == cDate && x.Email == email).Select(x => x.id).FirstOrDefault();
                return RedirectToAction("Edit", new { id = filteredData });*/
                return View();
            }
            else
            {
                return View();
            }
            //return View();
        }

        // POST: Dairies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Dairy_Entry")] Dairy dairy)
        {
            if (ModelState.IsValid)
            {

                DateTime currentDate = DateTime.Now.Date;
                dairy.Date = currentDate.ToString("yyyy-MM-dd");
                ViewBag.date_data = currentDate;
                dairy.Email = User.Identity.GetUserName();
                String cDate = currentDate.ToString("yyyy-MM-dd");

                db.Dairies.Add(dairy);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(dairy);
        }
        //*********************************************************
        //.............................

        // GET: Dairies/Create

        //...........................


        // GET: Dairies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dairy dairy = db.Dairies.Find(id);
            if (dairy == null)
            {
                return HttpNotFound();
            }
            return View(dairy);
        }

        // POST: Dairies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Dairy_Entry,Date")] Dairy dairy)
        {
            if (ModelState.IsValid)
            {
                dairy.Email = User.Identity.GetUserName();
                db.Entry(dairy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dairy);
        }

        // GET: Dairies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dairy dairy = db.Dairies.Find(id);
            if (dairy == null)
            {
                return HttpNotFound();
            }
            return View(dairy);
        }

        // POST: Dairies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dairy dairy = db.Dairies.Find(id);
            db.Dairies.Remove(dairy);
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
        [HttpPost]
        public ActionResult Index(String Date_name)
        {
            // Handle form submission here
            var email_data = User.Identity.GetUserName();
            var filteredData = db.Dairies.Where(x => x.Date == Date_name && x.Email == email_data).ToList();
            return View(filteredData);
        }
    }
}
