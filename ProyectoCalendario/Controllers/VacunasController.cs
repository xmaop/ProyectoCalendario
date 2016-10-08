using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoCalendario.Models;

namespace ProyectoCalendario.Controllers
{
    public class VacunasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vacunas
        public ActionResult Index()
        {
            return View(db.Vacunas.ToList());
        }

        // GET: Vacunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacuna vacuna = db.Vacunas.Find(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // GET: Vacunas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacunas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VacunaId,nombre")] Vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                db.Vacunas.Add(vacuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacuna);
        }

        // GET: Vacunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacuna vacuna = db.Vacunas.Find(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // POST: Vacunas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VacunaId,nombre")] Vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacuna);
        }

        // GET: Vacunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacuna vacuna = db.Vacunas.Find(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // POST: Vacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacuna vacuna = db.Vacunas.Find(id);
            db.Vacunas.Remove(vacuna);
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
