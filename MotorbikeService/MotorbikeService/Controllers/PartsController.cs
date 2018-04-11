using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MotorbikeService.Models;
using MotorbikeService.ViewModel;

namespace MotorbikeService.Controllers
{
    public class PartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Parts
        public ActionResult Index()
        {
            return View(db.Parts.ToList());
        }

        // GET: Parts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parts parts = db.Parts.Find(id);
            if (parts == null)
            {
                return HttpNotFound();
            }
            return View(parts);
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            var viewModel = new PartsViewModel();
            var works = db.ServiceWorks.ToList();
            var motorBikes = db.MotorBikes.ToList();

            viewModel.ListWorks = new SelectList(works, "Id", "Comment");
            viewModel.ListMotorBikes = new SelectList(motorBikes, "Id", "VIN");

            return View(viewModel);
        }

        // POST: Parts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( PartsViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Parts.Add(model.Parts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PartsViewModel viewModel = new PartsViewModel();
            viewModel.Parts = db.Parts.Find(id);

            var worksEdit = db.ServiceWorks.ToList();
            var motorBikesEdit = db.MotorBikes.ToList();

            viewModel.ListWorks = new SelectList(worksEdit, "Id", "Comment");
            viewModel.ListMotorBikes = new SelectList(motorBikesEdit, "Id", "VIN");


           // Parts parts = db.Parts.Find(id);
            if (viewModel.Parts == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Parts parts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parts);
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parts parts = db.Parts.Find(id);
            if (parts == null)
            {
                return HttpNotFound();
            }
            return View(parts);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parts parts = db.Parts.Find(id);
            db.Parts.Remove(parts);
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
