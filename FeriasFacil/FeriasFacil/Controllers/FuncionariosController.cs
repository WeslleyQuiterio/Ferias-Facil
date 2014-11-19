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
    public class FuncionariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionarios = db.Funcionarios.Include(f => f.Cargo).Include(f => f.Equipe).Include(f => f.Gerencia);
            return View(funcionarios.ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            ViewBag.CargoID = new SelectList(db.Cargos, "ID", "Nome");
            ViewBag.EquipeID = new SelectList(db.Equipes, "ID", "Nome");
            ViewBag.GerenciaID = new SelectList(db.Gerencias, "ID", "Nome");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,DataAdmissao,Email,Telefone,Endereco,FotoTipo,FotoNome,Foto,Matricula,CPF,GerenciaID,CargoID,EquipeID")] Funcionario funcionario, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //Salvar no Banco

                    funcionario.FotoTipo = image.ContentType;
                    funcionario.Foto = new byte[image.ContentLength];
                    funcionario.FotoNome = image.FileName;
                    image.InputStream.Read(funcionario.Foto, 0, image.ContentLength);
                    //Fim Salvar no Banco


                    //Salvar como arquivo    
                    /*
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    string directory = Server.MapPath("~/Uploads/");
                    if (!System.IO.Directory.Exists(directory))
                    {
                        System.IO.Directory.CreateDirectory(directory);
                    }
                    string path = System.IO.Path.Combine(directory, fileName);
                    image.SaveAs(path);

                    func.FotoNome = fileName;
                    func.FotoTipo = image.ContentType;
                     */

                }
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoID = new SelectList(db.Cargos, "ID", "Nome", funcionario.CargoID);
            ViewBag.EquipeID = new SelectList(db.Equipes, "ID", "Nome", funcionario.EquipeID);
            ViewBag.GerenciaID = new SelectList(db.Gerencias, "ID", "Nome", funcionario.GerenciaID);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoID = new SelectList(db.Cargos, "ID", "Nome", funcionario.CargoID);
            ViewBag.EquipeID = new SelectList(db.Equipes, "ID", "Nome", funcionario.EquipeID);
            ViewBag.GerenciaID = new SelectList(db.Gerencias, "ID", "Nome", funcionario.GerenciaID);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,DataAdmissao,Email,Telefone,Endereco,FotoTipo,FotoNome,Foto,Matricula,CPF,GerenciaID,CargoID,EquipeID")] Funcionario funcionario, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //Salvar no Banco

                    funcionario.FotoTipo = image.ContentType;
                    funcionario.Foto = new byte[image.ContentLength];
                    funcionario.FotoNome = image.FileName;
                    image.InputStream.Read(funcionario.Foto, 0, image.ContentLength);
                    //Fim Salvar no Banco


                    //Salvar como arquivo    
                    /*
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    string directory = Server.MapPath("~/Uploads/");
                    if (!System.IO.Directory.Exists(directory))
                    {
                        System.IO.Directory.CreateDirectory(directory);
                    }
                    string path = System.IO.Path.Combine(directory, fileName);
                    image.SaveAs(path);

                    func.FotoNome = fileName;
                    func.FotoTipo = image.ContentType;
                     */

                }

                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoID = new SelectList(db.Cargos, "ID", "Nome", funcionario.CargoID);
            ViewBag.EquipeID = new SelectList(db.Equipes, "ID", "Nome", funcionario.EquipeID);
            ViewBag.GerenciaID = new SelectList(db.Gerencias, "ID", "Nome", funcionario.GerenciaID);
            return View(funcionario);
        }
        public ActionResult GetImageDataBase(int id)
        {
            Funcionario func = db.Funcionarios.Find(id);
            return File(func.Foto, func.FotoTipo);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionario);
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
