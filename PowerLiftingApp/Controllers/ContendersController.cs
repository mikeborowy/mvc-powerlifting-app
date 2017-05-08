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
            //return View(db.Contenders.ToList());
            return View();
        }

        [HttpPost]
        public ActionResult Index(string[] contenderName)
        {
            using (db)
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
                            Deadlift = 0
                        };

                        db.Contenders.Add(contender);
                    }

                    db.SaveChanges();
                }

            }
            //return View(db.Contenders.ToList());
            
            return RedirectToAction("List");
        }

        // GET: Contenders/Details/5
        public ActionResult Details(int? id)
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

        // GET: Contenders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BenchPress,Squat,Deadlift")] Contender contender)
        {
            if (ModelState.IsValid)
            {
                db.Contenders.Add(contender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contender);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BenchPress,Squat,Deadlift")] Contender contender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contender);
        }

        // GET: Contenders/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Contenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contender contender = db.Contenders.Find(id);
            db.Contenders.Remove(contender);
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
