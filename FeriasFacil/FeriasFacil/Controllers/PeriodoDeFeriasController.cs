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
    public class PeriodoDeFeriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PeriodoDeFerias
        public ActionResult Index()
        {
            var periodoDeFerias = db.PeriodosDeFerias.Include(p => p.Funcionario);
            return View(periodoDeFerias.ToList());
        }

        // GET: PeriodoDeFerias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodoDeFerias periodoDeFerias = db.PeriodosDeFerias.Find(id);
            if (periodoDeFerias == null)
            {
                return HttpNotFound();
            }
            return View(periodoDeFerias);
        }

        // GET: PeriodoDeFerias/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "ID", "Nome");
            return View();
        }

        // POST: PeriodoDeFerias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AnoReferencia,FuncionarioID,DataVingencia,DataVencimento,Saldo")] PeriodoDeFerias periodoDeFerias)
        {
            if (ModelState.IsValid)
            {
                db.PeriodosDeFerias.Add(periodoDeFerias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "ID", "Nome", periodoDeFerias.FuncionarioID);
            return View(periodoDeFerias);
        }

        // GET: PeriodoDeFerias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodoDeFerias periodoDeFerias = db.PeriodosDeFerias.Find(id);
            if (periodoDeFerias == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "ID", "Nome", periodoDeFerias.FuncionarioID);
            return View(periodoDeFerias);
        }

        // POST: PeriodoDeFerias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AnoReferencia,FuncionarioID,DataVingencia,DataVencimento,Saldo")] PeriodoDeFerias periodoDeFerias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodoDeFerias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "ID", "Nome", periodoDeFerias.FuncionarioID);
            return View(periodoDeFerias);
        }

        // GET: PeriodoDeFerias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodoDeFerias periodoDeFerias = db.PeriodosDeFerias.Find(id);
            if (periodoDeFerias == null)
            {
                return HttpNotFound();
            }
            return View(periodoDeFerias);
        }

        // POST: PeriodoDeFerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeriodoDeFerias periodoDeFerias = db.PeriodosDeFerias.Find(id);
            db.PeriodosDeFerias.Remove(periodoDeFerias);
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
