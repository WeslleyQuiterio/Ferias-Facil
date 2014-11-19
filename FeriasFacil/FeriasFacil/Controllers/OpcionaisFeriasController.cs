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
    public class OpcionaisFeriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OpcionaisFerias
        public ActionResult Index()
        {
            return View(db.OpcionaisFerias.ToList());
        }

        // GET: OpcionaisFerias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionaisFerias opcionaisFerias = db.OpcionaisFerias.Find(id);
            if (opcionaisFerias == null)
            {
                return HttpNotFound();
            }
            return View(opcionaisFerias);
        }

        // GET: OpcionaisFerias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpcionaisFerias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Detalhes,Status")] OpcionaisFerias opcionaisFerias)
        {
            if (ModelState.IsValid)
            {
                db.OpcionaisFerias.Add(opcionaisFerias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opcionaisFerias);
        }

        // GET: OpcionaisFerias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionaisFerias opcionaisFerias = db.OpcionaisFerias.Find(id);
            if (opcionaisFerias == null)
            {
                return HttpNotFound();
            }
            return View(opcionaisFerias);
        }

        // POST: OpcionaisFerias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Detalhes,Status")] OpcionaisFerias opcionaisFerias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcionaisFerias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opcionaisFerias);
        }

        // GET: OpcionaisFerias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionaisFerias opcionaisFerias = db.OpcionaisFerias.Find(id);
            if (opcionaisFerias == null)
            {
                return HttpNotFound();
            }
            return View(opcionaisFerias);
        }

        // POST: OpcionaisFerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpcionaisFerias opcionaisFerias = db.OpcionaisFerias.Find(id);
            db.OpcionaisFerias.Remove(opcionaisFerias);
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
