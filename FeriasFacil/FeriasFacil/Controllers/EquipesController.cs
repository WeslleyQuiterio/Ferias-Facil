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
    public class EquipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Equipes
        public ActionResult Index()
        {
            var equipes = db.Equipes.Include(e => e.Gerencia);
            return View(equipes.ToList());
        }

        // GET: Equipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = db.Equipes.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // GET: Equipes/Create
        public ActionResult Create()
        {
            ViewBag.GerenciaID = new SelectList(db.Gerencias, "ID", "Nome");
            return View();
        }

        // POST: Equipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,GerenciaID")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Equipes.Add(equipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GerenciaID = new SelectList(db.Gerencias, "ID", "Nome", equipe.GerenciaID);
            return View(equipe);
        }

        // GET: Equipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = db.Equipes.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.GerenciaID = new SelectList(db.Gerencias, "ID", "Nome", equipe.GerenciaID);
            return View(equipe);
        }

        // POST: Equipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,GerenciaID")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GerenciaID = new SelectList(db.Gerencias, "ID", "Nome", equipe.GerenciaID);
            return View(equipe);
        }

        // GET: Equipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipe equipe = db.Equipes.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // POST: Equipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipe equipe = db.Equipes.Find(id);
            db.Equipes.Remove(equipe);
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
