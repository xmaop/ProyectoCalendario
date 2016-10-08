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
    public class PautasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pautas
        public ActionResult Index()
        {
            var pautas = db.Pautas.Include(p => p.vacuna);
            return View(pautas.ToList());
        }
        public ActionResult Filtra(int? id)
        {
            var detpautas = db.Pautas.Where(d => d.vacunaId == id);
            return View(detpautas.ToList());
        }

        // GET: Pautas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pauta pauta = db.Pautas.Find(id);
            if (pauta == null)
            {
                return HttpNotFound();
            }
            return View(pauta);
        }

        // GET: Pautas/Create
        public ActionResult Create()
        {
            ViewBag.vacunaId = new SelectList(db.Vacunas, "VacunaId", "nombre");
            return View();
        }

        // POST: Pautas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PautaId,vacunaId,numeroveces,tipotiempo,TI,PI,TF,PF")] Pauta pauta)
        {
            if (ModelState.IsValid)
            {
                db.Pautas.Add(pauta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vacunaId = new SelectList(db.Vacunas, "VacunaId", "nombre", pauta.vacunaId);
            return View(pauta);
        }

        // GET: Pautas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pauta pauta = db.Pautas.Find(id);
            if (pauta == null)
            {
                return HttpNotFound();
            }
            ViewBag.vacunaId = new SelectList(db.Vacunas, "VacunaId", "nombre", pauta.vacunaId);
            return View(pauta);
        }

        // POST: Pautas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PautaId,vacunaId,numeroveces,tipotiempo,TI,PI,TF,PF")] Pauta pauta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pauta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vacunaId = new SelectList(db.Vacunas, "VacunaId", "nombre", pauta.vacunaId);
            return View(pauta);
        }

        // GET: Pautas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pauta pauta = db.Pautas.Find(id);
            if (pauta == null)
            {
                return HttpNotFound();
            }
            return View(pauta);
        }

        // POST: Pautas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pauta pauta = db.Pautas.Find(id);
            db.Pautas.Remove(pauta);
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
