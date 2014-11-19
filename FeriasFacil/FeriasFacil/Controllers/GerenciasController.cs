using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FeriasFacil.Models;

namespace FeriasFacil.Controllers
{
    public class GerenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gerencias
        public ActionResult Index()
        {
            return View(db.Gerencias.ToList());
        }

        // GET: Gerencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerencia gerencia = db.Gerencias.Find(id);
            if (gerencia == null)
            {
                return HttpNotFound();
            }
            return View(gerencia);
        }

        // GET: Gerencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gerencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Telefone,Localizacao")] Gerencia gerencia)
        {
            if (ModelState.IsValid)
            {
                db.Gerencias.Add(gerencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gerencia);
        }

        // GET: Gerencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerencia gerencia = db.Gerencias.Find(id);
            if (gerencia == null)
            {
                return HttpNotFound();
            }
            return View(gerencia);
        }

        // POST: Gerencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Telefone,Localizacao")] Gerencia gerencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gerencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gerencia);
        }

        // GET: Gerencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerencia gerencia = db.Gerencias.Find(id);
            if (gerencia == null)
            {
                return HttpNotFound();
            }
            return View(gerencia);
        }

        // POST: Gerencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gerencia gerencia = db.Gerencias.Find(id);
            db.Gerencias.Remove(gerencia);
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
