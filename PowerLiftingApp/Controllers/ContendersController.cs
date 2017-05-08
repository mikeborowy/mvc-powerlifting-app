using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PowerLiftingApp.Context;
using PowerLiftingApp.Models;

namespace PowerLiftingApp.Controllers
{
    public class ContendersController : Controller
    {
        private PowerliftingDbContext db = new PowerliftingDbContext();

        // GET: Contenders
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string[] contenderName)
        {
            if (contenderName != null || contenderName.Length != 0)
            {
                foreach (var name in contenderName)
                {
                    Contender contender = new Contender()
                    {
                        Name = name,
                        BenchPress = 0,
                        Squat = 0,
                        Deadlift = 0,
                        TotalResult = 0
                    };

                    db.Contenders.Add(contender);
                }

                db.SaveChanges();
            }

            return RedirectToAction("Records");
        }

        public ActionResult Records()
        {
            return View(db.Contenders.ToList());
        }

        public ActionResult Results()
        {
            return View(db.Contenders.ToList().OrderByDescending(r => r.TotalResult));
        }

        // GET: Contenders/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Contenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contender contender = db.Contenders.Find(id);
            if (contender == null)
            {
                return HttpNotFound();
            }
            return View(contender);
        }

        // POST: Contenders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BenchPress,Squat,Deadlift")] Contender updatedContender)
        {
            if (ModelState.IsValid)
            {

                db.Contenders.Attach(updatedContender);
                var entry = db.Entry(updatedContender);
                entry.State = EntityState.Modified;

                if (entry.Property(r => r.BenchPress).IsModified ||
                    entry.Property(r => r.Squat).IsModified ||
                    entry.Property(r => r.Deadlift).IsModified)
                {
                    entry.Entity.TotalResult = entry.Entity.BenchPress + entry.Entity.Squat + entry.Entity.Deadlift;
                }

                db.SaveChanges();
                return RedirectToAction("Records");
            }
            return View(updatedContender);
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
