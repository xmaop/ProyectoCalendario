using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoCalendario.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoCalendario.Controllers
{
    public class ServicioClinicoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SqlConnection con;
        // GET: ServicioClinicoes
        public ActionResult Index()
        {
            return View(db.ServicioClinicoes.ToList());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateServi([Bind(Include = "ServicioClinicoId,ListaAtencionId,CalendarioId,detalleCalendarioId,pautasId,FF")] ServicioClinico servicioClinico)
        {
            if (ModelState.IsValid)
            {
                
                db.ServicioClinicoes.Add(servicioClinico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicioClinico);
        }


        // GET: ServicioClinicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioClinico servicioClinico = db.ServicioClinicoes.Find(id);
            if (servicioClinico == null)
            {
                return HttpNotFound();
            }
            return View(servicioClinico);
        }

        // GET: ServicioClinicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicioClinicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicioClinicoId,ListaAtencionId,CalendarioId,detalleCalendarioId,pautasId,FF")] ServicioClinico servicioClinico)
        {
            if (ModelState.IsValid)
            {
                db.ServicioClinicoes.Add(servicioClinico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicioClinico);
        }

        // GET: ServicioClinicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioClinico servicioClinico = db.ServicioClinicoes.Find(id);
            if (servicioClinico == null)
            {
                return HttpNotFound();
            }
            return View(servicioClinico);
        }

        // POST: ServicioClinicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicioClinicoId,ListaAtencionId,CalendarioId,detalleCalendarioId,pautasId,FF")] ServicioClinico servicioClinico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicioClinico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicioClinico);
        }

        // GET: ServicioClinicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioClinico servicioClinico = db.ServicioClinicoes.Find(id);
            if (servicioClinico == null)
            {
                return HttpNotFound();
            }
            return View(servicioClinico);
        }

        // POST: ServicioClinicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicioClinico servicioClinico = db.ServicioClinicoes.Find(id);
            db.ServicioClinicoes.Remove(servicioClinico);
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
