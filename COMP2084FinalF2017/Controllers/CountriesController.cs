using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP2084FinalF2017.Models;

namespace COMP2084FinalF2017.Controllers
{
    [Authorize]
    public class CountriesController : Controller
    {
        private ICountriesRepository db;

        public CountriesController()
        {
            this.db = new EFCountriesRepository();
        }

        public CountriesController(ICountriesRepository db)
        {
            this.db = db;
        }

        // GET: Countries
        public ViewResult Index()
        {
            return View(db.Countries.ToList().OrderByDescending(a => a.TotalMedals));
        }

        // GET: Countries/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Country country = db.Countries.FirstOrDefault(a => a.CountryID == id);
            if (country == null)
            {
                return View("Error");
            }
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryID,Country1,Gold,Silver,Bronze,TotalMedals,Flag")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Save(country);
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.FirstOrDefault(a => a.CountryID == id);
            if (country == null)
            {
                return View("Error");
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryID,Country1,Gold,Silver,Bronze,TotalMedals,Flag")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Save(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Country country = db.Countries.FirstOrDefault(a => a.CountryID == id);
            if (country == null)
            {
                return View("Error");
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ViewResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Country country = db.Countries.FirstOrDefault(a => a.CountryID == id);
            if (country == null)
            {
                return View("Error");
            }
            db.Delete(country);
            return View("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
