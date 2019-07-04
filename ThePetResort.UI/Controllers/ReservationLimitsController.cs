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
    public class ReservationLimitsController : Controller
    {
        private PetResortEntities db = new PetResortEntities();

        // GET: ReservationLimits
        public ActionResult Index()
        {
            var reservationLimits = db.ReservationLimits.Include(r => r.ResortLocation).Include(r => r.Type);
            return View(reservationLimits.ToList());
        }

        // GET: ReservationLimits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationLimit reservationLimit = db.ReservationLimits.Find(id);
            if (reservationLimit == null)
            {
                return HttpNotFound();
            }
            return View(reservationLimit);
        }

        // GET: ReservationLimits/Create
        public ActionResult Create()
        {
            ViewBag.ResortLocationID = new SelectList(db.ResortLocations, "ResortLocationID", "ResortName");
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Name");
            return View();
        }

        // POST: ReservationLimits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationLimitID,ResortLocationID,TypeID,Limit")] ReservationLimit reservationLimit)
        {
            if (ModelState.IsValid)
            {
                db.ReservationLimits.Add(reservationLimit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResortLocationID = new SelectList(db.ResortLocations, "ResortLocationID", "ResortName", reservationLimit.ResortLocationID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Name", reservationLimit.TypeID);
            return View(reservationLimit);
        }

        // GET: ReservationLimits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationLimit reservationLimit = db.ReservationLimits.Find(id);
            if (reservationLimit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResortLocationID = new SelectList(db.ResortLocations, "ResortLocationID", "ResortName", reservationLimit.ResortLocationID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Name", reservationLimit.TypeID);
            return View(reservationLimit);
        }

        // POST: ReservationLimits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationLimitID,ResortLocationID,TypeID,Limit")] ReservationLimit reservationLimit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationLimit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResortLocationID = new SelectList(db.ResortLocations, "ResortLocationID", "ResortName", reservationLimit.ResortLocationID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Name", reservationLimit.TypeID);
            return View(reservationLimit);
        }

        // GET: ReservationLimits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationLimit reservationLimit = db.ReservationLimits.Find(id);
            if (reservationLimit == null)
            {
                return HttpNotFound();
            }
            return View(reservationLimit);
        }

        // POST: ReservationLimits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationLimit reservationLimit = db.ReservationLimits.Find(id);
            db.ReservationLimits.Remove(reservationLimit);
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
