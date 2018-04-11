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
    public class ServiceWorkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ServiceWork
        public ActionResult Index()
        {
            return View(db.ServiceWorks.ToList());
        }

        // GET: ServiceWork/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceWork serviceWork = db.ServiceWorks.Find(id);
            if (serviceWork == null)
            {
                return HttpNotFound();
            }
            return View(serviceWork);
        }

        // GET: ServiceWork/Create
        public ActionResult Create()
        {
            var viewModel = new ServiceWorkViewModel();
            var parts = db.Parts.ToList();
            var motorBikes = db.MotorBikes.ToList();

            viewModel.ListMotorBikes = new SelectList(motorBikes, "Id", "VIN");
            viewModel.ListParts = new SelectList(parts, "Id", "Name");


            return View(viewModel);
        }

        // POST: ServiceWork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceWorkViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                db.ServiceWorks.Add(model.ServiceWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ServiceWork/Edit/5
        public ActionResult Edit(int? id)
        {
           

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceWork serviceWork = db.ServiceWorks.Find(id);
            if (serviceWork == null)
            {
                return HttpNotFound();
            }
            

            return View(serviceWork);
        }

        // POST: ServiceWork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceWorkViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model.ServiceWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ServiceWork/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceWork serviceWork = db.ServiceWorks.Find(id);
            if (serviceWork == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: ServiceWork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceWork serviceWork = db.ServiceWorks.Find(id);
            db.ServiceWorks.Remove(serviceWork);
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
