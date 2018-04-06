using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MotorbikeService.Models;

namespace MotorbikeService.Controllers
{
    public class MotorBikeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MotorBike
        public ActionResult Index()
        {
            return View(db.MotorBikes.ToList());
        }

        // GET: MotorBike/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorBike motorBike = db.MotorBikes.Find(id);
            if (motorBike == null)
            {
                return HttpNotFound();
            }
            return View(motorBike);
        }

        // GET: MotorBike/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotorBike/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( MotorBike motorBike)
        {
            if (ModelState.IsValid)
            {
                db.MotorBikes.Add(motorBike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motorBike);
        }

        // GET: MotorBike/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorBike motorBike = db.MotorBikes.Find(id);
            if (motorBike == null)
            {
                return HttpNotFound();
            }
            return View(motorBike);
        }

        // POST: MotorBike/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( MotorBike motorBike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motorBike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motorBike);
        }

        // GET: MotorBike/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotorBike motorBike = db.MotorBikes.Find(id);
            if (motorBike == null)
            {
                return HttpNotFound();
            }
            return View(motorBike);
        }

        // POST: MotorBike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MotorBike motorBike = db.MotorBikes.Find(id);
            db.MotorBikes.Remove(motorBike);
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
