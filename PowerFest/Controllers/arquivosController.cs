using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PowerFest;
using System.IO;

namespace PowerFest.Controllers
{
    public class arquivosController : Controller
    {
        private powerFestFinalEntities db = new powerFestFinalEntities();

        // GET: arquivos
        public ActionResult Index()
        {
            var arquivos = db.arquivos.Include(a => a.Servico);
            return View(arquivos.ToList());
        }

        // GET: arquivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arquivos arquivos = db.arquivos.Find(id);
            if (arquivos == null)
            {
                return HttpNotFound();
            }
            return View(arquivos);
        }

        // GET: arquivos/Create
        public ActionResult Create()
        {
            ViewBag.id_servico = new SelectList(db.Servico, "id_servico", "nome");
            return View();
        }

        // POST: arquivos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase UploadImage)
        {
            if (UploadImage.ContentLength > 0)
            {
                string ImageFile = Path.GetFileName(UploadImage.FileName);
                string folder = Path.Combine(Server.MapPath("~/UploadImages"),ImageFile);
                UploadImage.SaveAs(folder);

            }
            ViewBag.Message = "image salva";
            return View();
        }

        // GET: arquivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arquivos arquivos = db.arquivos.Find(id);
            if (arquivos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_servico = new SelectList(db.Servico, "id_servico", "nome", arquivos.id_servico);
            return View(arquivos);
        }

        // POST: arquivos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipo,caminho,id_arquivo,id_servico")] arquivos arquivos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arquivos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_servico = new SelectList(db.Servico, "id_servico", "nome", arquivos.id_servico);
            return View(arquivos);
        }

        // GET: arquivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arquivos arquivos = db.arquivos.Find(id);
            if (arquivos == null)
            {
                return HttpNotFound();
            }
            return View(arquivos);
        }

        // POST: arquivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            arquivos arquivos = db.arquivos.Find(id);
            db.arquivos.Remove(arquivos);
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
