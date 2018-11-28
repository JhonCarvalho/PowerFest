using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerFest.Controllers
{
    public class ServicoGeralController : Controller
    {
        private powerFestFinalEntities db = new powerFestFinalEntities();
        // GET: ServicoGeral
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServicoGeral/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicoGeral/Create
        public ActionResult Create()
        {
            viewModelServico viewModelServico = new viewModelServico();           
            var categoria = db.categoria.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var c in categoria)
            {

                list.Add(new SelectListItem
                {
                    Text = c.tipo,
                    Value = c.id_categoria.ToString()

                });

            }
            ViewBag.dropCategoria = list;
            return View();
           
        }

        // POST: ServicoGeral/Create
        [HttpPost]
        public ActionResult Create(viewModelServico viewModelServico)
        {
            try
            {
               /* var images = viewModelServico.images;

                if (images.Length > 0)
                {
                    foreach (HttpPostedFileBase img in images) {
                        string ImageFile = Path.GetFileName(img.FileName);
                        string folder = Path.Combine(Server.MapPath("~/UploadImages"), ImageFile);
                        img.SaveAs(folder);
                    }

                }*/

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicoGeral/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicoGeral/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicoGeral/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicoGeral/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
