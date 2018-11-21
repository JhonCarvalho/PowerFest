using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PowerFest;

namespace PowerFest.Controllers
{
    public class EmpresasController : Controller
    {
        private powerFestFinalEntities db = new powerFestFinalEntities();

        // GET: Empresas
        public ActionResult Index()
        {
            var empresa = db.Empresa.Include(e => e.contato).Include(e => e.Servico);
            return View(empresa.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            ViewBag.cpf = new SelectList(db.contato, "cpf", "cidade");
            ViewBag.id_servico = new SelectList(db.Servico, "id_servico", "nome");
            return View();
        }

        // POST: Empresas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cnpj,logradouro,pais,razao_social,cidade,rua,estado,email,cpf,id_servico,telefone2,telefone1")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresa.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cpf = new SelectList(db.contato, "cpf", "id_contato", empresa.id_contato);
            ViewBag.id_servico = new SelectList(db.Servico, "id_servico", "nome", empresa.id_servico);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.cpf = new SelectList(db.contato, "id_contato", "cidade", empresa.id_contato);
            ViewBag.id_servico = new SelectList(db.Servico, "id_servico", "nome", empresa.id_servico);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cnpj,logradouro,pais,razao_social,cidade,rua,estado,email,cpf,id_servico,telefone2,telefone1")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cpf = new SelectList(db.contato, "id_contato", "cidade", empresa.id_contato);
            ViewBag.id_servico = new SelectList(db.Servico, "id_servico", "nome", empresa.id_servico);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Empresa empresa = db.Empresa.Find(id);
            db.Empresa.Remove(empresa);
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
