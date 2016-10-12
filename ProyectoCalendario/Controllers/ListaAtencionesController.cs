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
    public class ListaAtencionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListaAtenciones
        public ActionResult Index()
        {
            var listaAtencions = db.ListaAtencions.Include(l => l.cliente).Include(l => l.especie).Include(l => l.mascota);
            return View(listaAtencions.ToList());
        }

        // GET: ListaAtenciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaAtencion listaAtencion = db.ListaAtencions.Find(id);
            if (listaAtencion == null)
            {
                return HttpNotFound();
            }
            return View(listaAtencion);
        }

        // GET: ListaAtenciones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nombreCliente");
            ViewBag.EspecieId = new SelectList(db.Especies, "EspecieId", "nombre");
            ViewBag.MascotaId = new SelectList(db.Mascotas, "MascotaId", "nombreMascota");
            return View();
        }

        // POST: ListaAtenciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListaAtencionId,ClienteId,MascotaId,EspecieId,fechaAtencion,horaAtencion")] ListaAtencion listaAtencion)
        {
            if (ModelState.IsValid)
            {
                db.ListaAtencions.Add(listaAtencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nombreCliente", listaAtencion.ClienteId);
            ViewBag.EspecieId = new SelectList(db.Especies, "EspecieId", "nombre", listaAtencion.EspecieId);
            ViewBag.MascotaId = new SelectList(db.Mascotas, "MascotaId", "nombreMascota", listaAtencion.MascotaId);
            return View(listaAtencion);
        }

        

        // GET: ListaAtenciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaAtencion listaAtencion = db.ListaAtencions.Find(id);
            if (listaAtencion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nombreCliente", listaAtencion.ClienteId);
            ViewBag.EspecieId = new SelectList(db.Especies, "EspecieId", "nombre", listaAtencion.EspecieId);
            ViewBag.MascotaId = new SelectList(db.Mascotas, "MascotaId", "nombreMascota", listaAtencion.MascotaId);
            return View(listaAtencion);
        }

        // POST: ListaAtenciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListaAtencionId,ClienteId,MascotaId,EspecieId,fechaAtencion,horaAtencion")] ListaAtencion listaAtencion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaAtencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nombreCliente", listaAtencion.ClienteId);
            ViewBag.EspecieId = new SelectList(db.Especies, "EspecieId", "nombre", listaAtencion.EspecieId);
            ViewBag.MascotaId = new SelectList(db.Mascotas, "MascotaId", "nombreMascota", listaAtencion.MascotaId);
            return View(listaAtencion);
        }

        // GET: ListaAtenciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaAtencion listaAtencion = db.ListaAtencions.Find(id);
            if (listaAtencion == null)
            {
                return HttpNotFound();
            }
            return View(listaAtencion);
        }

        // POST: ListaAtenciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaAtencion listaAtencion = db.ListaAtencions.Find(id);
            db.ListaAtencions.Remove(listaAtencion);
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
