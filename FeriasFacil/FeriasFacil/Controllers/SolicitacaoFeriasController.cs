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
    public class SolicitacaoFeriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SolicitacaoFerias
        public ActionResult Index()
        {
            var solicitacaoFerias = db.SolicitacoesFerias.Include(s => s.PeriodoDeFerias);
            return View(solicitacaoFerias.ToList());
        }

        // GET: SolicitacaoFerias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoFerias solicitacaoFerias = db.SolicitacoesFerias.Find(id);
            if (solicitacaoFerias == null)
            {
                return HttpNotFound();
            }
            return View(solicitacaoFerias);
        }

        // GET: SolicitacaoFerias/Create
        public ActionResult Create()
        {
            ViewBag.PeriodoDeFeriasID = new SelectList(db.PeriodosDeFerias, "ID", "ID");
            return View();
        }

        // POST: SolicitacaoFerias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PeriodoDeFeriasID,DataInicial,DataFinal,QuantidadeDias")] SolicitacaoFerias solicitacaoFerias)
        {
            if (ModelState.IsValid)
            {
                db.SolicitacoesFerias.Add(solicitacaoFerias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PeriodoDeFeriasID = new SelectList(db.PeriodosDeFerias, "ID", "ID", solicitacaoFerias.PeriodoDeFeriasID);
            return View(solicitacaoFerias);
        }

        // GET: SolicitacaoFerias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoFerias solicitacaoFerias = db.SolicitacoesFerias.Find(id);
            if (solicitacaoFerias == null)
            {
                return HttpNotFound();
            }
            ViewBag.PeriodoDeFeriasID = new SelectList(db.PeriodosDeFerias, "ID", "ID", solicitacaoFerias.PeriodoDeFeriasID);
            return View(solicitacaoFerias);
        }

        // POST: SolicitacaoFerias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PeriodoDeFeriasID,DataInicial,DataFinal,QuantidadeDias")] SolicitacaoFerias solicitacaoFerias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitacaoFerias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PeriodoDeFeriasID = new SelectList(db.PeriodosDeFerias, "ID", "ID", solicitacaoFerias.PeriodoDeFeriasID);
            return View(solicitacaoFerias);
        }

        // GET: SolicitacaoFerias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitacaoFerias solicitacaoFerias = db.SolicitacoesFerias.Find(id);
            if (solicitacaoFerias == null)
            {
                return HttpNotFound();
            }
            return View(solicitacaoFerias);
        }

        // POST: SolicitacaoFerias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitacaoFerias solicitacaoFerias = db.SolicitacoesFerias.Find(id);
            db.SolicitacoesFerias.Remove(solicitacaoFerias);
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
