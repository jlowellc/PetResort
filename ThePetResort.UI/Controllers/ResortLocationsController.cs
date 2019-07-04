using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThePetResort.DAL;

namespace ThePetResort.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ResortLocationsController : Controller
    {
        private PetResortEntities db = new PetResortEntities();

        // GET: ResortLocations
        public ActionResult Index()
        {
            return View(db.ResortLocations.ToList());
        }

        // GET: ResortLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResortLocation resortLocation = db.ResortLocations.Find(id);
            if (resortLocation == null)
            {
                return HttpNotFound();
            }
            return View(resortLocation);
        }

        // GET: ResortLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResortLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResortLocationID,ResortName,Address,City,State,ZipCode,Phone")] ResortLocation resortLocation)
        {
            if (ModelState.IsValid)
            {
                db.ResortLocations.Add(resortLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resortLocation);
        }

        // GET: ResortLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResortLocation resortLocation = db.ResortLocations.Find(id);
            if (resortLocation == null)
            {
                return HttpNotFound();
            }
            return View(resortLocation);
        }

        // POST: ResortLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResortLocationID,ResortName,Address,City,State,ZipCode,Phone")] ResortLocation resortLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resortLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resortLocation);
        }

        // GET: ResortLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResortLocation resortLocation = db.ResortLocations.Find(id);
            if (resortLocation == null)
            {
                return HttpNotFound();
            }
            return View(resortLocation);
        }

        // POST: ResortLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResortLocation resortLocation = db.ResortLocations.Find(id);
            db.ResortLocations.Remove(resortLocation);
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
