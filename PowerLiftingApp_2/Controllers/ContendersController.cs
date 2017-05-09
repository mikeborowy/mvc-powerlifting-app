using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PowerLiftingApp_2.Context;
using PowerLiftingApp_2.Models;
using PowerLiftingApp_2.ViewModels;

namespace PowerLiftingApp_2.Controllers
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
        public ActionResult Index(int contendersNo)
        {
            //return RedirectToAction("Records");
            return RedirectToAction("Records", new
            {
                c = contendersNo
            });
        }

        public ActionResult Records(int c)
        {
            ContenderViewModel cvm = new ContenderViewModel();

            for (var i = 0; i < c; i++)
            {

                Contender initContender = new Contender();
                initContender.Name = "name";
                initContender.BenchPress = 0;
                initContender.Squat = 0;
                initContender.Deadlift = 0;
                initContender.TotalResult = 0;

                cvm.ContendersList.Add(initContender);
            }

            return View(cvm);
        }

        [HttpPost]
        public ActionResult Records(ContenderViewModel cvm)
        {
            foreach (var item in cvm.ContendersList)
            {
                Contender newContender = new Contender();
                newContender.Name = item.Name;
                newContender.BenchPress = item.BenchPress;
                newContender.Squat = item.Squat;
                newContender.Deadlift = item.Deadlift;
                newContender.TotalResult = item.BenchPress + item.Squat + item.Deadlift;

                if (ModelState.IsValid)
                {
                    db.Contenders.Add(newContender);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Results");
        }

        public ActionResult Results()
        {
            return View(db.Contenders.ToList().OrderByDescending(r => r.TotalResult));
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
