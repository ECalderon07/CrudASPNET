using Autores.Models;
using Autores.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autores.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            List<AutorViewModel> list;

            using (Modelo db = new Modelo())
            {
                list = (from a in db.Autor
                        select new AutorViewModel
                        {
                            id = a.id,
                            nombre = a.nombre,
                            nacionalidad = a.nacionalidad
                        }).ToList();
            }

            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AutorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Modelo db = new Modelo())
                    {
                        var autor = new Autor();

                        autor.nombre = model.nombre;
                        autor.nacionalidad = model.nacionalidad;

                        db.Autor.Add(autor);
                        db.SaveChanges();
                    }
                    return Redirect("~/Autor/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Update(int id)
        {
            AutorViewModel model = new AutorViewModel();

            using (Modelo db = new Modelo())
            {

                var autor = db.Autor.Find(id);
                model.nombre = autor.nombre;
                model.nacionalidad = autor.nacionalidad;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AutorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Modelo db = new Modelo())
                    {
                        var autor = db.Autor.Find(model.id);

                        autor.nombre = model.nombre;
                        autor.nacionalidad = model.nacionalidad;

                        db.Entry(autor).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Autor/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {

            using (Modelo db = new Modelo())
            {
                var autor = db.Autor.Find(id);
                db.Autor.Remove(autor);
                db.SaveChanges();
            }

            return Redirect("~/Autor/");
        }
    }
}