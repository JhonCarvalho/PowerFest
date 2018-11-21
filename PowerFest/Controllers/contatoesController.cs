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
    public class contatoesController : Controller
    {
        private powerFestFinalEntities db = new powerFestFinalEntities();

        // GET: contatoes
        public ActionResult Index()
        {
            var contato = db.contato.Include(c => c.Usuario);
            return View(contato.ToList());
        }

        // GET: contatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contato contato = db.contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: contatoes/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "login");
            return View();
        }

        // POST: contatoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cidade,nome,cpf,dt_nascimento,logradouro,pais,estado,numero,rua,id_usuario,telefone1,telefone2")] contato contato)
        {
            if (ModelState.IsValid)
            {
                db.contato.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "login", contato.id_usuario);
            return View(contato);
        }

        // GET: contatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contato contato = db.contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "login", contato.id_usuario);
            return View(contato);
        }

        // POST: contatoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cidade,nome,cpf,dt_nascimento,logradouro,pais,estado,numero,rua,id_usuario,telefone1,telefone2")] contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "login", contato.id_usuario);
            return View(contato);
        }

        // GET: contatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contato contato = db.contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: contatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contato contato = db.contato.Find(id);
            db.contato.Remove(contato);
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
