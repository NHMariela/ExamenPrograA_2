using ExamenPrograA_2.Models;
using ExamenPrograA_2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ExamenPrograA_2.Controllers
{
    public class PreguntasController : Controller
    {
        // GET: Pregunta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pregunta/Create
        [HttpPost]
        public ActionResult Create(Models.Preguntas model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (FincaAgricolaDBEntities db = new FincaAgricolaDBEntities())
                    {
                        model.Fecha = DateTime.Now;
                        db.Preguntas.Add(model);
                        db.SaveChanges();

                        TempData["Mensaje"] = "Pregunta enviada correctamente";
                        return RedirectToAction("Create");
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Error: {ex.Message}";
                return View(model);
            }
        }
    }
}
