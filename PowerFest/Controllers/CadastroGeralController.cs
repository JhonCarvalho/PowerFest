using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerFest.Controllers
{
    public class CadastroGeralController : Controller
    {
        private powerFestFinalEntities db = new powerFestFinalEntities();

        // GET: CadastroGeral
        public ActionResult Index()
        {
          
            return View();
        }

        // GET: CadastroGeral/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadastroGeral/Create
        public ActionResult Create()
        {
            viewModelCadastro viewModelCadastro = new viewModelCadastro();
            var perfil = db.Perfil.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var p in perfil)
            {           

                list.Add(new SelectListItem
                {
                    Text = p.tipo,
                    Value = p.id_perfil.ToString()

                });

                /*dropPerfil dp = new dropPerfil();
                dp.id_perfil = p.id_perfil;
                dp.tipo = p.tipo;
                lis.Add(dp);*/

            }


            /*viewModelCadastro.perfil = db.Perfil.ToList().Select(perfil => new Perfil {
                Value = perfil.id_perfil.ToString(),
                Text  = perfil.tipo
            }).ToList();*/
            //ViewBag.id_perfil = new SelectList(db.Perfil, "id_perfil", "tipo");
            ViewBag.dropPerfil = list;
            return View();
        }

        // POST: CadastroGeral/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(viewModelCadastro viewModelCadastro)
        {
            
            try
            {

                //Usuario;
                Usuario usuario = viewModelCadastro.Usuario;
                usuario.dt_cadastro = DateTime.Now;
                usuario.id_perfil = 1;
                db.Usuario.Add(usuario);
                db.SaveChanges();
                int id_usuario = usuario.id_usuario;

                //Contato
                contato contato = viewModelCadastro.contato;
                contato.id_usuario = id_usuario;
                db.contato.Add(contato);
                db.SaveChanges();
                int id_contato = contato.id_contato;
                //Empresa
                Empresa empresa = viewModelCadastro.empresa;
                empresa.id_contato = id_contato;
                db.Empresa.Add(empresa);
                db.SaveChanges();

                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.id_perfil = new SelectList(db.Perfil, "id_perfil", "tipo");
                return View();
            }
        }

        // GET: CadastroGeral/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadastroGeral/Edit/5
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

        // GET: CadastroGeral/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadastroGeral/Delete/5
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
