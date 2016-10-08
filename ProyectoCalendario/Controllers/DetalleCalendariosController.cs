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
    public class DetalleCalendariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DetalleCalendarios
        public ActionResult Index()
        {
            var detalleCalendarios = db.DetalleCalendarios.Include(d => d.calendario).Include(d => d.vacuna);
            return View(detalleCalendarios.ToList());
        }
        public ActionResult Filtra(int? id)
        {
             var detcalendario = db.DetalleCalendarios.Where(d => d.CalendarioId == id);
            return View(detcalendario.ToList());
        }
        // GET: DetalleCalendarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCalendario detalleCalendario = db.DetalleCalendarios.Find(id);
            if (detalleCalendario == null)
            {
                return HttpNotFound();
            }
            return View(detalleCalendario);
        }

        // GET: DetalleCalendarios/Create
        public ActionResult Create()
        {
            ViewBag.CalendarioId = new SelectList(db.Calendarios, "CalendarioId", "nombre");
            ViewBag.VacunaId = new SelectList(db.Vacunas, "VacunaId", "nombre");
            return View();
        }

        // POST: DetalleCalendarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DetallecalendarioId,CalendarioId,VacunaId,edadmin,edadmax,numeroveces,viaaplicacion,volumen,unidad,efectos")] DetalleCalendario detalleCalendario)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCalendarios.Add(detalleCalendario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CalendarioId = new SelectList(db.Calendarios, "CalendarioId", "nombre", detalleCalendario.CalendarioId);
            ViewBag.VacunaId = new SelectList(db.Vacunas, "VacunaId", "nombre", detalleCalendario.VacunaId);
            return View(detalleCalendario);
        }

        // GET: DetalleCalendarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCalendario detalleCalendario = db.DetalleCalendarios.Find(id);
            if (detalleCalendario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CalendarioId = new SelectList(db.Calendarios, "CalendarioId", "nombre", detalleCalendario.CalendarioId);
            ViewBag.VacunaId = new SelectList(db.Vacunas, "VacunaId", "nombre", detalleCalendario.VacunaId);
            return View(detalleCalendario);
        }

        // POST: DetalleCalendarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DetallecalendarioId,CalendarioId,VacunaId,edadmin,edadmax,numeroveces,viaaplicacion,volumen,unidad,efectos")] DetalleCalendario detalleCalendario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCalendario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CalendarioId = new SelectList(db.Calendarios, "CalendarioId", "nombre", detalleCalendario.CalendarioId);
            ViewBag.VacunaId = new SelectList(db.Vacunas, "VacunaId", "nombre", detalleCalendario.VacunaId);
            return View(detalleCalendario);
        }

        // GET: DetalleCalendarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCalendario detalleCalendario = db.DetalleCalendarios.Find(id);
            if (detalleCalendario == null)
            {
                return HttpNotFound();
            }
            return View(detalleCalendario);
        }

        // POST: DetalleCalendarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCalendario detalleCalendario = db.DetalleCalendarios.Find(id);
            db.DetalleCalendarios.Remove(detalleCalendario);
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
