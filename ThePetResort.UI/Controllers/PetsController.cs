using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cStoreMVC.UI.Exceptions;
using PetResort.UI.Services;
using ThePetResort.DAL;

namespace ThePetResort.UI.Controllers
{
    public class PetsController : Controller
    {
        private readonly PetResortEntities db = new PetResortEntities();

        // GET: Pets
        public ActionResult Index()
        {
            var pets = db.Pets.Include(p => p.Type);
            return View(pets.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Name");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,Name,TypeID,PetPhoto,SpecialNotes,IsVIP,DateAdded")] Pet pet, HttpPostedFileBase PetPhoto)
        {
            if (ModelState.IsValid)
            {
                var imageName = "";

                var imgExt = Path.GetExtension(PetPhoto?.FileName);
                if (imgExt != null)
                {
                    imgExt = imgExt.ToLower();
                    string[] allowedExtensions = { ".png", ".jpg", ".jpeg", ".gif" };

                    if (allowedExtensions.Contains(imgExt))
                    {

                        imageName = Path.GetFileName(PetPhoto.FileName);

                        string savePath = Server.MapPath("~/Content/img/pets/");

                        Image convertedImage = Image.FromStream(PetPhoto.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageService.ResizeImage(savePath, imageName, convertedImage, maxImageSize, maxThumbSize);
                    }
                    else
                    {
                        throw new InvalidFileTypeException("Invalid file type. Only .png, .jpg, or .jpeg files allowed.");
                    }
                }

                pet.PetPhoto = imageName;

                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Name", pet.TypeID);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID,Name,TypeID,PetPhoto,SpecialNotes,IsVIP,DateAdded")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Name", pet.TypeID);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            db.Pets.Remove(pet);
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
